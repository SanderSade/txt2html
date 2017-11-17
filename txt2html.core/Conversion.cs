using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Sander.txt2html
{
	internal sealed class Conversion
	{
		private static readonly char[] EolSymbols = { '.', '"', '!', '?', '\'', '…' };
		private static readonly Regex UrlRegex = new Regex(
			@"((www\.|(http|https|ftp|news|file)+\:\/\/)[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])",
			RegexOptions.IgnoreCase | RegexOptions.Compiled);
		private readonly bool _fixParagraphs;
		private readonly StringBuilder _sb;
		private readonly ConversionSettings _settings;
		private Dictionary<string, string> _entities;


		/// <inheritdoc />
		public Conversion(ConversionSettings settings)
		{
			_settings = settings;
			_sb = new StringBuilder();
			_sb.AppendLine("<!DOCTYPE html>\r\n<html>\r\n<head>\r\n<meta charset = \"UTF-8\">");
			_fixParagraphs = _settings.MinimumLineLength.HasValue;

			if (_settings.CreateEntities)
				PrepareEntities();
		}


		private void PrepareEntities()
		{
			string[] lines;
			const string txt2HtmlEnt = "txt2html.ent";
			if (File.Exists(txt2HtmlEnt))
			{
				lines = File.ReadAllLines(txt2HtmlEnt, Encoding.UTF8);
			}
			else
			{
				var resourceName = FormattableString.Invariant($"Sander.txt2html.{txt2HtmlEnt}");
				var assembly = Assembly.GetExecutingAssembly();
				using (var stream = assembly.GetManifestResourceStream(resourceName))
					using (var reader = new StreamReader(stream))
					{
						var result = reader.ReadToEnd();
						lines = result.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
					}
			}
			_entities = new Dictionary<string, string>();
			foreach (var line in lines)
			{
				var split = line.Split('\t');
				if (split.Length != 2)
					throw new ApplicationException($"Bad line in {txt2HtmlEnt}: {line}. Every line must be in format <character><tab><entity>");
				//Debug.WriteLine(split[0]);
				_entities.Add(split[0], split[1]);
			}
		}


		internal string Convert(string[] fileContent)
		{
			if (!string.IsNullOrWhiteSpace(_settings.Title))
				_sb.AppendLine($"<title>{(_settings.CreateEntities && _entities?.Count > 0 ? EncodeCharacters(_settings.Title) : _settings.Title)}</title>");

			if (!string.IsNullOrWhiteSpace(_settings.Css))
			{

				_sb.AppendLine($"<style>\r\n{_settings.Css}\r\n</style>");
			}

			_sb.AppendLine("</head>\r\n<body>");

			ConvertBody(fileContent);

			_sb.AppendLine("</body>\r\n</html>");
			return Encoding.UTF8.GetString(Encoding.Default.GetBytes(_sb.ToString()));
		}


		private void ConvertBody(string[] fileContent)
		{
			/*
			 * Merge paragraphs
			 * Run HTML conversion (critical symbols)
			 * Convert non-critical entities
			 * Run bold conversion
			 * Run italic conversion
			 * Detect URL's
			 * Add <p></p>
			 */

			for (var i = 0; i < fileContent.Length; i++)
			{
				var current = fileContent[i];

				if (!GetValidLine(ref current))
					continue;

				if (_fixParagraphs)
					MergeParagraphs(fileContent, ref i, ref current);

				var encoded = HttpUtility.HtmlEncode(current);

				if (_settings.CreateEntities && _entities?.Count > 0)
					encoded = EncodeCharacters(encoded);

				if (_settings.FixBold)
					FixItalicOrBold(ref encoded, '*', "strong");

				if (_settings.FixItalic)
					FixItalicOrBold(ref encoded, '_', "em");

				if (_settings.DetectUrls)
					encoded = ReplaceUrls(encoded);

				_sb.AppendLine($"<p>{encoded}</p>");
			}
		}


		private string EncodeCharacters(string encoded)
		{
			foreach (var entity in _entities)
			{
				Debug.Assert(encoded != null, "encoded != null");
				encoded = encoded.Replace(entity.Key, entity.Value);
			}
			return encoded;
		}


		/// <summary>
		/// Finds web addresses in a string and adds a tags
		/// <para>Adapted from http://rickyrosario.com/blog/converting-a-url-into-a-link-in-csharp-using-regular-expressions/ </para>
		/// </summary>
		internal static string ReplaceUrls(string line)
		{
			return UrlRegex.Replace(line, "<a href=\"$1\">$1</a>");
		}


		internal static void FixItalicOrBold(ref string encoded, char marker, string tagcontent)
		{
			var loc = 0;
			var isStart = true;
			while (true)
			{
				var first = encoded.IndexOf(marker, loc);
				if (first == -1)
					break;

				var next = encoded.IndexOf(marker, first + 1);
				if (isStart && next == -1)
					break;

				encoded = encoded.Remove(first, 1);
				var tag = isStart ? string.Empty : "/";
				encoded = encoded.Insert(first, $"<{tag}{tagcontent}>");
				isStart = !isStart;
			}
		}


		internal void MergeParagraphs(string[] fileContent, ref int i, ref string current)
		{
			Debug.Assert(_settings.MinimumLineLength != null, "_fixParagraphs would be false");
			while (i < fileContent.Length && (!EolSymbols.Contains(current[current.Length - 1]) || current.Length < _settings.MinimumLineLength.Value))
			{
				if (i + 1 >= fileContent.Length)
					break;

				var next = fileContent[i + 1];

				//if next is empty line, consider the line ended
				if (next.Trim().Length == 0)
					break;

				++i;

				if (!GetValidLine(ref next))
					continue;
				current += $" {next}";
			}
		}


		private bool GetValidLine(ref string current)
		{
			if (current == null)
				return false;

			current = current.Trim();

			while (current.Contains("  "))
				current = current.Replace("  ", " ");

			//keep extra valid line breaks, but don't process them further
			if (current.Length == 0)
				_sb.AppendLine("<br/>");

			return !string.IsNullOrWhiteSpace(current);
		}
	}
}
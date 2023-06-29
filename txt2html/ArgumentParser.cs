using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sander.txt2html.console
{
	internal static class ArgumentParser
	{
		internal static ConversionArguments Parse(params string[] args)
		{
			var result = new ConversionArguments
			{
				ConversionSettings = new ConversionSettings(),
				InputFile = args[0].Trim(' ', '"')
			};

			if (!File.Exists(result.InputFile))
			{
				ErrorExit($"File {result.InputFile} does not exist!");
			}

			if (args.Length == 1)
			{
				result.OutputFile = Path.ChangeExtension(result.InputFile, "html");
				result.ConversionSettings.Title = Path.GetFileNameWithoutExtension(result.OutputFile);
				return result;
			}

			var arguments = args.Skip(1).Select(x => x.Trim(' ', '-', '/')).ToList();
			result.ConversionSettings.FixBold = GetSimpleKeyExists(arguments, "bold");
			result.ConversionSettings.FixItalic = GetSimpleKeyExists(arguments, "italic");
			result.ConversionSettings.DetectUrls = GetSimpleKeyExists(arguments, "urls");
			result.ConversionSettings.CreateEntities = GetSimpleKeyExists(arguments, "entities");

			result.OutputFile = GetSplitValue(arguments, "o") ?? Path.ChangeExtension(result.InputFile, "html");
			result.ConversionSettings.Title = GetSplitValue(arguments, "t") ?? Path.GetFileNameWithoutExtension(result.OutputFile);

			var cssFile = GetSplitValue(arguments, "css");
			if (cssFile != null)
			{
				if (!File.Exists(cssFile))
				{
					ErrorExit($"CSS file {cssFile} does not exist!");
				}

				result.ConversionSettings.Css = File.ReadAllText(cssFile, Encoding.UTF8);
			}

			var line = GetSplitValue(arguments, "fixparagraphs");

			if (!string.IsNullOrWhiteSpace(line))
			{
				if (uint.TryParse(line, out var lineLength))
				{
					result.ConversionSettings.MinimumLineLength = lineLength;
				}
			}

			return result;
		}


		private static string GetSplitValue(List<string> arguments, string key)
		{
			var argument = arguments.FirstOrDefault(x => x.StartsWith(key, StringComparison.OrdinalIgnoreCase));
			if (argument == null)
			{
				return null;
			}

			var startIndex = argument.IndexOf(":", StringComparison.Ordinal);

			if (startIndex == -1 || startIndex == argument.Length - 1)
			{
				ErrorExit(
					$"Argument '-{argument}' requires value after semicolon, e.g. -fixparagraphs:50 or -title:\"Collected works of William Shakespeare\"");
			}

			var value = argument.Substring(startIndex + 1);

			return value.Trim('"', ' ');
		}


		private static bool GetSimpleKeyExists(List<string> arguments, string key)
		{
			return arguments.Any(x => string.Compare(x, key, StringComparison.OrdinalIgnoreCase) == 0);
		}


		internal static void ErrorExit(string error)
		{
			var oldColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(error);
			Console.ForegroundColor = oldColor;

			Environment.Exit(1);
		}
	}
}

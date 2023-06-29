using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("text2html.test")]

namespace Sander.txt2html
{
	/// <summary>
	///     Main txt2html conversion functionality
	/// </summary>
	public static class Converter
	{
		/// <summary>
		///     Convert the specified text
		/// </summary>
		public static string Convert(ConversionSettings conversionSettings, IEnumerable<string> fileContent)
		{
			if (conversionSettings == null)
			{
				throw new ArgumentNullException(nameof(conversionSettings));
			}

			if (fileContent == null)
			{
				throw new ArgumentNullException(nameof(fileContent));
			}

			//think about this. Bad for speed & memory use, but easier iteration etc for paragraph merging
			var contentArray = fileContent.ToList();
			if (contentArray.Count == 0)
			{
				throw new ArgumentException("Value cannot be an empty collection.", nameof(fileContent));
			}

			return new Conversion(conversionSettings).Convert(contentArray);
		}


		/// <summary>
		///     Convert the specified file. Throws an exception if the file does not exist
		///     If encoding is not specified, .NET attempts to auto-detect the encoding
		/// </summary>
		public static string Convert(ConversionSettings conversionSettings, string fileName, Encoding encoding = null)
		{
			if (string.IsNullOrWhiteSpace(fileName) || !File.Exists(fileName))
			{
				throw new FileNotFoundException($"File \"{fileName}\" does not exist!");
			}

			return Convert(conversionSettings, encoding == null ? File.ReadAllLines(fileName) : File.ReadAllLines(fileName, encoding));
		}


		/// <summary>
		///     Convert the specified file opened in stream, optionally specifying encoding (UTF-8 is assumed if not set)
		///     It is up to the caller to set the proper start position in the stream.
		///     FileStream is not disposed.
		/// </summary>
		public static async Task<string> ConvertAsync(ConversionSettings conversionSettings, FileStream fileStream, Encoding encoding = null)
		{
			if (fileStream == null)
			{
				throw new NullReferenceException("Filestream cannot be null!");
			}

			if (!fileStream.CanRead)
			{
				throw new FileLoadException($"Filestream \"{fileStream.Name}\" is not readable!");
			}

			encoding = encoding ?? Encoding.UTF8;

			using (var reader = new StreamReader(fileStream, encoding))
			{
				return await ConvertAsync(conversionSettings, reader).ConfigureAwait(false);
			}
		}


		/// <summary>
		///     Converts the text in the specified stream reader.
		///     It is up to the caller to set the proper position in the base stream
		///     Neither StreamReader nor base stream is disposed.
		/// </summary>
		public static async Task<string> ConvertAsync(ConversionSettings conversionSettings, StreamReader reader)
		{
			if (reader == null)
			{
				throw new NullReferenceException("Reader cannot be null!");
			}

			var lines = new List<string>(256);
			while (!reader.EndOfStream)
			{
				lines.Add(await reader.ReadLineAsync().ConfigureAwait(false));
			}

			return Convert(conversionSettings, lines);
		}


		/// <summary>
		///     Convert the specified file opened in stream, optionally specifying encoding (UTF-8 is assumed if not set)
		///     It is up to the caller to set the proper start position in the stream.
		///     FileStream is not disposed.
		/// </summary>
		public static string Convert(ConversionSettings conversionSettings, FileStream fileStream, Encoding encoding = null)
		{
			if (fileStream == null)
			{
				throw new NullReferenceException("Filestream cannot be null!");
			}

			if (!fileStream.CanRead)
			{
				throw new FileLoadException($"Filestream \"{fileStream.Name}\" is not readable!");
			}

			encoding = encoding ?? Encoding.UTF8;

			using (var reader = new StreamReader(fileStream, encoding))
			{
				return Convert(conversionSettings, reader);
			}
		}


		/// <summary>
		///     Converts the text in the specified stream reader.
		///     It is up to the caller to set the proper position in the base stream
		///     Neither StreamReader nor base stream is disposed.
		/// </summary>
		public static string Convert(ConversionSettings conversionSettings, StreamReader reader)
		{
			if (reader == null)
			{
				throw new NullReferenceException("Reader cannot be null!");
			}

			var lines = new List<string>(256);
			while (!reader.EndOfStream)
			{
				lines.Add(reader.ReadLine());
			}


			return Convert(conversionSettings, lines);
		}
	}
}

using System;
using System.IO;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("text2html.test")]
namespace Sander.txt2html
{
    public static class Converter
    {
        /// <summary>
        /// Convert the specified text
        /// </summary>
        public static string Convert(ConversionSettings conversionSettings, string[] fileContent)
        {
            if (conversionSettings == null) throw new ArgumentNullException(nameof(conversionSettings));
            if (fileContent == null) throw new ArgumentNullException(nameof(fileContent));
            if (fileContent.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(fileContent));

            return new Conversion(conversionSettings).Convert(fileContent);
        }


        /// <summary>
        /// Convert the specified file. Throws an exception if the file does not exist
        /// </summary>
        public static string Convert(ConversionSettings conversionSettings, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName) || !File.Exists(fileName))
                throw new FileNotFoundException($"File \"{fileName}\" does not exist!");

            return Convert(conversionSettings, File.ReadAllLines(fileName));
        }
    }
}
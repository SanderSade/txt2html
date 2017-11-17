using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Sander.txt2html.console
{
    internal class Program
    {
        internal static void Main(params string[] args)
        {
            Console.WriteLine("txt2html utility by DukeLupus/Sander Säde.\r\n\t\thttps://github.com/SanderSade/txt2html");

            if (args == null || args.Length == 0 || args.Any(x => x.Contains("?")))
            {
                ShowHelp();
                Environment.Exit(2);
            }

            var sw = Stopwatch.StartNew();
            var arguments = ArgumentParser.Parse(args);
            var lines = File.ReadAllLines(arguments.InputFile);

            Console.WriteLine($"Converting \"{Path.GetFullPath(arguments.InputFile)}\"\r\n\tto \"{Path.GetFullPath(arguments.OutputFile)}\"");
            var html = Converter.Convert(arguments.ConversionSettings, lines);
            File.WriteAllText(arguments.OutputFile, html, Encoding.UTF8);
            sw.Stop();
            Console.WriteLine($"Conversion successful. Total time was {sw.Elapsed}");
        }


        private static void ShowHelp()
        {
            Console.WriteLine("Text to HTML conversion utility.");
            Console.WriteLine("Usage (optional arguments are in parentheses []): ");
            Console.WriteLine(
                "\ttxthtml \"<input file>\" [-o:\"<output file>\"] [-t:\"<title>\"] [-css:\"<css file>\"] [-bold] [-italic] [-urls] [-entities] [-fixparagraphs:<minimum line length>]");
            Console.WriteLine();
            Console.WriteLine("Input file -- just name or full path to the input text file");
            Console.WriteLine(
                "-o:<output file> -- Optional, if omitted input file with the .html extension will be used. Can have a full path. WARNING: output file will be overwritten if it exists!");
            Console.WriteLine("-t:<title> -- Optional title. Defaults to input filename without extension if omitted.");
            Console.WriteLine("-css:<css file> -- custom CSS file to include. Optional.");
            Console.WriteLine("-bold -- Fix *text* to HTML bold. Optional, defaults to false (no conversion) if omitted");
            Console.WriteLine("-italic -- Fix _text_ to HTML italic/emphasis. Optional, defaults to false (no conversion) if omitted");
            Console.WriteLine("-urls -- Detect URL's and make them clickable. Optional, defaults to false");
            Console.WriteLine(
                "-entities -- replace characters with HTML entities. The characters are in file txt2html.ent, use Notepad to edit it. This functionality can also be used to replace any character or string.");
            Console.WriteLine(
                "-fixparagraphs:<minimum line length> -- Attempt to merge hard-coded line-breaks into coherent paragraphs. Lines shorter than <minimum line length> symbols which don't end with characters marking end of line ('.?!\") are joined.");
            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine(
                "txt2html \"c:\\Books\\Collected works of Shakespeare.txt\" -- convert the specified file with default options, output file will be \"c:\\Books\\Collected works of Shakespeare.html\"");
            Console.WriteLine(
                "txt2html \"c:\\Books\\Collected works of Shakespeare.txt\" -o:\"c:\\HTML Books\\Collected-Shakespeare.html\" -- convert the specified file with default options, specifying an output file");
            Console.WriteLine(
                "txt2html \"c:\\Books\\Collected works of Shakespeare.txt\" -bold -italic -t:\"Complete collected works of William Shakespeare\"  -- title is specified, bold and italic are fixed");
            Console.WriteLine("txt2html \"c:\\Books\\Collected works of Shakespeare.txt\" -css:\"c:\\CSS\\clean.css\" -- include custom CSS to the book.");
            Console.WriteLine(
                "txt2html \"c:\\Books\\Collected works of Shakespeare.txt\" -fixparagraphs:45 -- attempt to merge paragraphs at 45 characters");

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

using System.Diagnostics;
using System.IO;
using DukeLupus.txt2html.console;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace text2html.test
{
    [TestClass]
    public class ConsoleAppTest
    {
        private static void Write(object displayObject)
        {
            var settings = new JsonSerializerSettings() { ContractResolver = new InternalFieldResolver(), Formatting = Formatting.Indented, NullValueHandling = NullValueHandling.Ignore };
            var text = JsonConvert.SerializeObject(displayObject, settings);
            Trace.WriteLine(text);
        }


        [TestMethod]
        public void ArgumentParser_ParseSimple()
        {
            var settings = ArgumentParser.Parse("t8.shakespeare.txt");
            Write(settings);
            Assert.AreEqual("t8.shakespeare.txt", settings.InputFile);
            Assert.AreEqual("t8.shakespeare", settings.ConversionSettings.Title);
            Assert.AreEqual(Path.ChangeExtension(settings.InputFile, "html"), settings.OutputFile);
        }

        [TestMethod]
        public void ArgumentParser_ParseBoldUrl()
        {
            var settings = ArgumentParser.Parse("t8.shakespeare.txt", "-bold", "/urls", "-italic");
            Write(settings);
            Assert.IsTrue(settings.ConversionSettings.DetectUrls);
            Assert.IsTrue(settings.ConversionSettings.FixBold);
            Assert.IsTrue(settings.ConversionSettings.FixItalic);
            Assert.IsFalse(settings.ConversionSettings.CreateEntities);
        }


        [TestMethod]
        public void ArgumentParser_ParseTitle()
        {
            var settings = ArgumentParser.Parse("t8.shakespeare.txt", "/t:\"Collected Works\"");
            Write(settings);
            Assert.AreEqual("Collected Works", settings.ConversionSettings.Title);
        }



        [TestMethod]
        public void ArgumentParser_ParseParagraphFix()
        {
            var settings = ArgumentParser.Parse("t8.shakespeare.txt", "fixparagraphs:22");
            Write(settings);
            Assert.IsTrue(22 == settings.ConversionSettings.MinimumLineLength);
        }


        [TestMethod]
        public void Main_Simple()
        {
            Program.Main("t8.shakespeare.txt");
            Assert.IsTrue(File.Exists("t8.shakespeare.html"));
        }


        [TestMethod]
        public void Main_Complex()
        {
            Program.Main("t8.shakespeare.txt", "-t:\"Collected works\"", "-bold", "italic", "/urls", "entities", "-fixparagraphs:60", "o:shakespeare.complex.html");
            Assert.IsTrue(File.Exists("shakespeare.complex.html"));
        }
    }
}
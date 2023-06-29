using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sander.txt2html;

namespace text2html.test
{
	[TestClass]
	public class ConversionTest
	{
		[TestMethod]
		public void Conversion_TestBoldFix()
		{
			var toFix = "This is *really* important";
			Conversion.FixItalicOrBold(ref toFix, '*', "strong");
			Trace.WriteLine(toFix);
			Assert.AreEqual("This is <strong>really</strong> important", toFix);
		}


		[TestMethod]
		public void Conversion_TestBoldFixWithExtra()
		{
			var toFix = "This is *really* important*";
			Conversion.FixItalicOrBold(ref toFix, '*', "strong");
			Trace.WriteLine(toFix);
			Assert.AreEqual("This is <strong>really</strong> important*", toFix);
		}


		[TestMethod]
		public void Conversion_TestMultipleBoldFix()
		{
			var toFix = "This is *really* important and *needs* to be handled carefully";
			Conversion.FixItalicOrBold(ref toFix, '*', "strong");
			Trace.WriteLine(toFix);
			Assert.AreEqual("This is <strong>really</strong> important and <strong>needs</strong> to be handled carefully", toFix);
		}


		[TestMethod]
		public void Conversion_TestUrlReplace()
		{
			var toFix = "First we go to www.microsoft.com, then to http://google.com, then to https://www.facebook.com, and finally https://github.com";
			toFix = Conversion.ReplaceUrls(toFix);
			Trace.WriteLine(toFix);
			Assert.AreEqual(
				"First we go to <a href=\"www.microsoft.com\">www.microsoft.com</a>, then to <a href=\"http://google.com\">http://google.com</a>, then to <a href=\"https://www.facebook.com\">https://www.facebook.com</a>, and finally <a href=\"https://github.com\">https://github.com</a>",
				toFix);
		}


		[TestMethod]
		public void Conversion_TestFullConversion()
		{
			var conversion = new Conversion(new ConversionSettings
			{
				DetectUrls = true,
				FixBold = true,
				FixItalic = true,
				MinimumLineLength = 50,
				Title = "Lorem Ipsum"
			});

			var text = new[]
			{
				"Lorem ipsum dolor sit amet,", "consectetur adipiscing elit. ", "Haec quo *modo* _conveniant_, non sane intellego.",
				"Sed virtutem ipsam inchoavit, nihil amplius. ", "", "Non dolere, inquam, istud quam vim habeat postea videro; ",
				"Duo Reges: constructio interrete. www.example.com. ", "Sed quid sentiat, non videtis. At iste non dolendi status non vocatur voluptas."
			};

			var result = conversion.Convert(text.ToList());
			Trace.WriteLine(result);
			//not much else to do besides eyeballing the result
			Assert.AreEqual(553, result.Length);
		}


		[TestMethod]
		public void Conversion_TestEntityConversion()
		{
			var conversion = new Conversion(new ConversionSettings
			{
				CreateEntities = true,
				Title = "€"
			});

			var text = new[] { "$_`¢£¤¥§¨©ª«¬®" };

			var result = conversion.Convert(text.ToList());
			Trace.WriteLine(result);
			Assert.AreEqual(211, result.Length);
		}


		[TestMethod]
		public void Conversion_Shakespeare()
		{
			var text = File.ReadAllLines("t8.shakespeare.txt");

			var sw = Stopwatch.StartNew();
			var conversion = new Conversion(new ConversionSettings());
			var result = conversion.Convert(text.ToList());
			sw.Stop();
			Trace.WriteLine($"Converted Shakespeare without any options: {sw.Elapsed}");
			File.WriteAllText("Shakespeare.plain.html", result);


			sw = Stopwatch.StartNew();
			conversion = new Conversion(new ConversionSettings
			{
				FixBold = true,
				FixItalic = true
			});

			result = conversion.Convert(text.ToList());
			sw.Stop();
			Trace.WriteLine($"Converted Shakespeare with bold and italic: {sw.Elapsed}");
			File.WriteAllText("Shakespeare.bolditalic.html", result);

			sw = Stopwatch.StartNew();
			conversion = new Conversion(new ConversionSettings { MinimumLineLength = 50 });
			result = conversion.Convert(text.ToList());
			sw.Stop();
			Trace.WriteLine($"Converted Shakespeare with lines: {sw.Elapsed}");
			File.WriteAllText("Shakespeare.lines.html", result);


			sw = Stopwatch.StartNew();
			conversion = new Conversion(new ConversionSettings
			{
				FixBold = true,
				FixItalic = true,
				MinimumLineLength = 50
			});

			result = conversion.Convert(text.ToList());
			sw.Stop();
			Trace.WriteLine($"Converted Shakespeare with bold, italic and line fixes: {sw.Elapsed}");
			File.WriteAllText("Shakespeare.bolditaliclines.html", result);


			sw = Stopwatch.StartNew();
			conversion = new Conversion(new ConversionSettings
			{
				FixBold = true,
				FixItalic = true,
				MinimumLineLength = 50,
				CreateEntities = true
			});

			result = conversion.Convert(text.ToList());
			sw.Stop();
			Trace.WriteLine($"Converted Shakespeare with bold, italic, line fixes and entities: {sw.Elapsed}");
			File.WriteAllText("Shakespeare.bolditaliclinesentities.html", result);
		}


		[TestMethod]
		public void Conversion_File()
		{
			var result = Converter.Convert(new ConversionSettings(), "t8.shakespeare.txt");
			Trace.WriteLine(result.Substring(0, 30000));
		}


		[TestMethod]
		public void Conversion_FileStream()
		{
			using (var fs = new FileStream("t8.shakespeare.txt", FileMode.Open, FileAccess.Read))
			{
				fs.Position = 0;
				var result = Converter.ConvertAsync(new ConversionSettings
				{
					DetectUrls = true,
					FixBold = true,
					FixItalic = true
				}, fs, Encoding.ASCII).GetAwaiter().GetResult();

				Trace.WriteLine(result.Substring(0, 30000));
				//Assert.AreEqual(Converter.Convert(new ConversionSettings(), "t8.shakespeare.txt"), result);
			}
		}


		[TestMethod]
		public void Conversion_TestChineseAndJapaneseConversion()
		{
			string Convert(string text, string title)
			{
				var conversion = new Conversion(new ConversionSettings
				{
					CreateEntities = true,
					Title = title
				});

				var input = new[] { text };

				var result = conversion.Convert(input.ToList());
				Trace.WriteLine(result);

				return result;
			}

			Assert.IsTrue(Convert("我喜欢吃苹果", "我 Chinese").Contains("我喜欢吃苹果"));
			Assert.IsTrue(Convert("私はりんごが好きです", "私 Japanese").Contains("私はりんごが好きです"));
		}
	}
}

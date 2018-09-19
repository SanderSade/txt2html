[![GitHub license](https://img.shields.io/badge/licence-MPL%202.0-brightgreen.svg)](https://github.com/SanderSade/UrlShortener/blob/master/LICENSE)
[![NetStandard 2.0](https://img.shields.io/badge/-.NET%20Standard%202.0-green.svg)](https://github.com/dotnet/standard/blob/master/docs/versions/netstandard2.0.md)
[![NuGet v1.1.0](https://img.shields.io/badge/NuGet-v2.0.1-lightgrey.svg)](https://www.nuget.org/packages/Sander.txt2html/)

## Introduction

Use txt2html to convert plain text files to the hypertext markup language (HTML).

Features:
* Clean and compliant HTML5
* Option to include your own CSS
* HTML entity replacement (optional; you can also edit the entity list). Note that critical entities (&lt;,&gt;,",&amp;) are always replaced, so generally you don't have to enable this option
* Detects and fixes  `_italic_` and `*bold*` (optional)
* Detects and marks URL's (optional)
* Supports specifying encoding
* Optional paragraph joining. Attempts to merge hard-coded line-breaks into coherent paragraphs. Lines shorter than specified length, which don't end with characters marking end of line ('.?!") are joined.
* Fast (v2 is more than 50x faster than v1!)
* Free and open source

### Examples

**Full example**

```
var conversionSettings = new ConversionSettings()
	{ DetectUrls = true, FixBold = true, FixItalic = true, MinimumLineLength = 50, Title = "Lorem Ipsum"};

var text = new[]
	{
	"Lorem ipsum dolor sit amet,",
	"consectetur adipiscing elit. ",
	"Haec quo *modo* _conveniant_, non sane intellego.",
	"Sed virtutem ipsam inchoavit, nihil amplius. ",
	"",
	"Non dolere, inquam, istud quam vim habeat postea videro; ",
	"Duo Reges: constructio interrete. www.example.com. ",
	"Sed quid sentiat, non videtis. At iste non dolendi status non vocatur voluptas."
	};

var result = Converter.Convert(conversionSettings, text.ToList());
```

**Methods**

All described methods have `async` counterparts, with method name being `ConvertAsync()` instead of `Convert()`.

```
//Using existing strings (IEnumerable<string>)
string result = Converter.Convert(settings, content);
//Specify the file to use as source, optionally specifying encoding (if omitted, .NET will attempt to auto-detect the encoding
string result = Converter.Convert(settings, @"d:\texts\Shakespeare.txt", Encoding.ASCII);
//Specify file stream to use as a source, and optional encoding. It is up to the caller to set the proper position in the file
//FileStream is not disposed.
FileStream fs = File.OpenRead(@"d:\texts\Shakespeare.txt");
fs.Position = 42;
string result = Converter.Convert(settings, fs, Encoding.Unicode);
//Convert text from stream reader
//Neither StreamReader nor base stream is disposed
StreamReader sr = new StreamReader(@"d:\texts\Shakespeare.txt")
string result = Converter.Convert(settings, sr);

```

### Conversion settings

[ConversionSettings.cs](https://raw.githubusercontent.com/SanderSade/txt2html/master/txt2html.core/ConversionSettings.cs) allows you to control various settings for text conversion.

* `bool FixBold`: Set to true to wrap the text between `*asterisks*` with &lt;strong&gt;. Defaults to false.
* `bool FixItalic`:  Set to true to wrap the text between `_underscores_` with &lt;em&gt;. Defaults to false.
* `bool DetectUrls`: Detect and mark URLs. All www, http, https, ftp, news and file protocols/markers are supported.
* `uint? MinimumLineLength`: Minimum line length to use for paragraph joining. Lines shorter than specified length, which don't end with characters marking end of line ('.?!") are joined. Defaults to null (joining disabled)
* `bool CreateEntities`: Set to true to HTML entity replacement. Change txt2html.ent to specify what is changed. Note that critical entities (&gt; &lt; &quot; &amp;) are always replaced. If you don't include entities file (txt2html.ent), txt2html uses the [embedded default entities list](https://raw.githubusercontent.com/SanderSade/txt2html/master/txt2html.core/txt2html.ent). Defaults to false
* `string Css`: Include custom CSS to the conversion result. String should contain the actual CSS, not file path. Defaults to null (no special CSS)
* `string Title`: Set the HTML title for conversion. Defaults to null (no title)


### Changelog

See the main [readme](https://github.com/SanderSade/txt2html/blob/master/README.md).
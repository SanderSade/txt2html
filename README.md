[![GitHub license](https://img.shields.io/badge/licence-MPL%202.0-brightgreen.svg)](https://github.com/SanderSade/txt2html/blob/master/LICENSE.txt)
[![NetStandard 2.0](https://img.shields.io/badge/-.NET%20Standard%202.0-green.svg)](https://github.com/dotnet/standard/blob/master/docs/versions/netstandard2.0.md)
[![NuGet v2.0.2](https://img.shields.io/badge/NuGet-v2.0.2-lightgrey.svg)](https://www.nuget.org/packages/Sander.txt2html/)


# txt2html
txt2html is a program to convert plain text files to the hypertext markup language (HTML).

![txt2html](https://cloud.githubusercontent.com/assets/18664267/26674887/91636272-46ca-11e7-8be0-2e15e29a1df4.png)

### Features
* Clean and compliant HTML5
* Option to include your own CSS
* HTML entity replacement (optional; you can also edit the entity list). Note that critical entities (<,>,",&) are always replaced, so generally you don't have to enable this option
* Detects and fixes `_italic_` and `*bold*` (optional)
* Detects and marks URLs (optional)
* Optional paragraph joining. Attempts to merge hard-coded line-breaks into coherent paragraphs. Lines shorter than specified length, which don't end with characters marking end of line ('.?!") are joined.
* Fast (v2 is more than 50x faster than v1!)
* Supports converting multiple files at once
* Drag'n'drop
* Both graphical and command-line interface
* Free and open source
* Also available as a NuGet package - https://www.nuget.org/packages/Sander.txt2html

### Installing
To install, just extract all files from the archive to any folder and double-click on txt2htmlUI.exe to start using the program. The commandline version of txt2html is txt2html.exe

### Uninstalling
Delete all files

### Command-line options
```
Optional arguments are in parentheses []:  
        txthtml.exe "<input file>" [-o:"<output file>"] [-t:"<title>"] [-css:"<css file>"] [-bold] [-italic] [-urls] [-entities] [-fixparagraphs:<minimum line length>]  
        
Input file -- just name or full path to the input text file
-o:<output file> -- Optional, if omitted input file with the .html extension will be used. Can have a full path. WARNING: output file will be overwritten if it exists!
-t:<title> -- Optional title. Defaults to input filename without extension if omitted.
-css:<css file> -- custom CSS file to include. Optional.
-bold -- Fix *text* to HTML bold. Optional, defaults to false (no conversion) if omitted
-italic -- Fix _text_ to HTML italic/emphasis. Optional, defaults to false (no conversion) if omitted
-urls -- Detect URL's and make them clickable. Optional, defaults to false
-entities -- replace characters with HTML entities. The characters are in file txt2html.ent, use Notepad to edit it. This functionality can also be used to replace any character or string. If the entities file does not exist, [embedded default entities list](https://raw.githubusercontent.com/SanderSade/txt2html/master/txt2html.core/txt2html.ent) is used.
-fixparagraphs:<minimum line length> -- Attempt to merge hard-coded line-breaks into coherent paragraphs. Lines shorter than <minimum line length> symbols which don't end with characters marking end of line ('.?!") are joined.

Examples:
txt2html "c:\Books\Collected works of Shakespeare.txt" -- convert the specified file with default options, output file will be "c:\Books\Collected works of Shakespeare.html"
txt2html "c:\Books\Collected works of Shakespeare.txt" -o:"c:\HTML Books\Collected-Shakespeare.html" -- convert the specified file with default options, specifying an output file
txt2html "c:\Books\Collected works of Shakespeare.txt" -bold -italic -t:"Complete collected works of William Shakespeare"  -- title is specified, bold and italic are fixed
txt2html "c:\Books\Collected works of Shakespeare.txt" -css:"c:\CSS\clean.css" -- include custom CSS to the book.
txt2html "c:\Books\Collected works of Shakespeare.txt" -fixparagraphs:45 -- attempt to merge paragraphs at 45 characters
```

### License and home page
txt2html is licensed under [Mozilla Public License](https://github.com/SanderSade/txt2html/blob/master/LICENSE.txt)

[Home page](http://dukelupus.com/txt2html) has an older (non-.NET) version of txt2html, which you can use on Windows Vista and other older versions of Windows

### Version info
* 2.0
  * Complete rewrite in .NET
  * Major functional changes compared to v1 are:
    * HTML5 (was XHTML)
    * Supports drag'n'drop
    * Multi-file support
    * Right-click Explorer option no longer available (adding menu items for .txt seems to be blocked in Windows 10. I could easily add shortcut for .text, but not .txt)
    * Slightly improved paragraph joining
    * Option to add the title
* 2.0.1
  * txt2html.core is now NetStandard 2.0 library
  * Added NuGet package creation
  * Change namespace to Sander.txt2html
  * Update NuGet package (Newtonsoft.Json used by tests)
  * Embed default entities file to core dll to be used as fallback when the file isn't found
  * Added .editorConfig
  * Updated documentation
* 2.0.2
  * Fixed issue with UTF-8 vs default encoding ([Issue #3](https://github.com/SanderSade/txt2html/issues/3)) - thanks to [tigros](https://github.com/tigros) for reporting it!
  * Updated Newtonsoft.Json (used by tests).
  * Code cleanup.
* 2.0.3
  * Renamed txt2html.exe (UI) to txt2htmlUI.exe to avoid confusion with the commandline txt2html.exe ([Issue #6](https://github.com/SanderSade/txt2html/issues/6) - thanks to [Owned67](https://github.com/Owned67) for reporting it!)
  * Re-include the commandline txt2html to release, as it was accidentaly omitted in 2.0.2.
  * Very minor code cleanup, new .editorConfig.
  * NOTE: this will most likely be the last release on .NET Framework, and the future releases will target .NET 6 or higher.
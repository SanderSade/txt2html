# txt2html
txt2html is a program to convert plain text files to the hypertext markup language (HTML).

![txt2html](https://cloud.githubusercontent.com/assets/18664267/26674887/91636272-46ca-11e7-8be0-2e15e29a1df4.png)

### Features
* Clean and compliant HTML5
* Option to include your own CSS
* HTML entity replacement (optional; you can also edit the entity list). Note that critical entities (<,>,",&) are always replaced, so generally you don't have to enable this option
* Detects and fixes `_italic_` and `*bold*` (optional)
* Detects and marks URL's (optional)
* Optional paragraph joining. Attempts to merge hard-coded line-breaks into coherent paragraphs. Lines shorter than specfied length, which don't end with characters marking end of line ('.?!") are joined.
* Fast (v2 is more than 50x faster than v1!)
* Supports converting multiple files at once
* Drag'n'drop
* Both graphical and command-line interface
* Free and open source

### Installing
To install, just extract all files from the archive to any folder and double-click on txt2html.exe to start using the program.

### Uninstalling
Delete all files

### Command-line options
```
Optional arguments are in parentheses []:  
        txthtml "<input file>" [-o:"<output file>"] [-t:"<title>"] [-css:"<css file>"] [-bold] [-italic] [-urls] [-entities] [-fixparagraphs:<minimum line length>]  
        
Input file -- just name or full path to the input text file
-o:<output file> -- Optional, if omitted input file with the .html extension will be used. Can have a full path. WARNING: output file will be overwritten if it exists!
-t:<title> -- Optional title. Defaults to input filename without extension if omitted.
-css:<css file> -- custom CSS file to include. Optional.
-bold -- Fix *text* to HTML bold. Optional, defaults to false (no conversion) if omitted
-italic -- Fix _text_ to HTML italic/emphasis. Optional, defaults to false (no conversion) if omitted
-urls -- Detect URL's and make them clickable. Optional, defaults to false
-entities -- replace characters with HTML entities. The characters are in file txt2html.ent, use Notepad to edit it. This functionality can also be used to replace any character or string.
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

[Home page](http://dukelupus.com/txt2html) has some more information and older (non-.NET) version of txt2html

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

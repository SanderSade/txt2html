namespace Sander.txt2html
{
    public sealed class ConversionSettings
    {
        /// <summary>
        /// Fix *bold*
        /// </summary>
        public bool FixBold { get; set; }

        /// <summary>
        /// Fix _italic_
        /// </summary>
        public bool FixItalic { get; set; }

        /// <summary>
        /// Detect and mark URLs
        /// </summary>
        public bool DetectUrls { get; set; }

        /// <summary>
        /// Minimum line length when fixing paragraphs. Use null to disable
        /// </summary>
        public uint? MinimumLineLength { get; set; }

        /// <summary>
        /// HTML entity replacement. Change txt2html.ent to specify what is changed. Note that critical entities (&gt;&lt;&quot;&amp;) are always replaced
        /// </summary>
        public bool CreateEntities { get; set; }

        /// <summary>
        /// Include custom CSS. Leave null to disable.
        /// </summary>
        public string Css { get; set; }

        /// <summary>
        /// Title to be used in HTML
        /// </summary>
        public string Title { get; set; }
    }
}
namespace WkHtmlConverter
{
    public class HeaderSettings : ISettings
    {
        /// <summary>
        /// header.fontSize The font size to use for the header, e.g. "13"
        /// </summary>
        [PropertySetting("header.fontSize")]
        public int? FontSize { get; set; }

        /// <summary>
        /// header.fontName The name of the font to use for the header. e.g. "times"
        /// </summary>
        [PropertySetting("header.fontName")]
        public string? FontName { get; set; }

        /// <summary>
        /// header.left The string to print in the left part of the header, note that some sequences are replaced in this string, see the wkhtmltopdf manual.
        /// </summary>
        [PropertySetting("header.left")] 
        public string? Left { get; set; }

        /// <summary>
        /// header.center The text to print in the center part of the header.
        /// </summary>
        [PropertySetting("header.center")]
        public string? Center { get; set; }

        /// <summary>
        /// header.right The text to print in the right part of the header.
        /// </summary>
        [PropertySetting("header.right")]
        public string? Right { get; set; }

        /// <summary>
        /// header.line Whether a line should be printed under the header (either "true" or "false").
        /// </summary>
        [PropertySetting("header.line")]
        public bool? Line { get; set; }

        /// <summary>
        /// header.spacing The amount of space to put between the header and the content, e.g. "1.8". Be aware that if this is too large the header will be
        /// printed outside the PDF document. This can be corrected with the margin.top setting.
        /// </summary>
        [PropertySetting("header.spacing")]
        public double? Spacing { get; set; }

        /// <summary>
        /// header.htmlUrl URL or local path for a HTML document to use for the header.
        /// If specified all other parameters are ignored
        /// </summary>
        [PropertySetting("header.htmlUrl")]
        public string? Url { get; set; }
    }
}
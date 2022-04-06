namespace WkHtmlConverter
{
    public class FooterSettings : ISettings
    {
        /// <summary>
        /// footer.fontSize The font size to use for the footer, e.g. "13"
        /// </summary>
        [PropertySetting("footer.fontSize")]
        public int? FontSize { get; set; }

        /// <summary>
        /// footer.fontName The name of the font to use for the footer. e.g. "times"
        /// </summary>
        [PropertySetting("footer.fontName")]
        public string? FontName { get; set; }

        /// <summary>
        /// footer.left The string to print in the left part of the footer, note that some sequences are replaced in this string, see the wkhtmltopdf manual.
        /// </summary>
        [PropertySetting("footer.left")]
        public string? Left { get; set; }

        /// <summary>
        /// footer.center The text to print in the center part of the footer.
        /// </summary>
        [PropertySetting("footer.center")]
        public string? Center { get; set; }

        /// <summary>
        /// footer.right The text to print in the right part of the footer.
        /// </summary>
        [PropertySetting("footer.right")]
        public string? Right { get; set; }

        /// <summary>
        /// footer.line Whether a line should be printed under the footer (either "true" or "false").
        /// </summary>
        [PropertySetting("footer.line")]
        public bool? Line { get; set; }

        /// <summary>
        /// footer.spacing The amount of space to put between the footer and the content, e.g. "1.8". Be aware that if this is too large the footer will be
        /// printed outside the PDF document. This can be corrected with the margin.top setting.
        /// </summary>
        [PropertySetting("footer.spacing")]
        public double? Spacing { get; set; }

        /// <summary>
        /// footer.htmlUrl URL or local path for a HTML document to use for the footer.
        /// If specified all other parameters are ignored
        /// </summary>
        [PropertySetting("footer.htmlUrl")]
        public string? Url { get; set; }
    }
}
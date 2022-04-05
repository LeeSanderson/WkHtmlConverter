namespace WkHtmlConverter
{
    public class TableOfContentSettings : ISettings
    {
        /// <summary>
        /// toc.useDottedLines Should we use a dotted line when creating a table of content? Must be either "true" or "false".
        /// </summary>
        [PropertySetting("toc.useDottedLines")]
        public bool? UseDottedLines { get; set; }

        /// <summary>
        /// toc.captionText The caption to use when creating a table of content.
        /// </summary>
        [PropertySetting("toc.captionText")]
        public string? CaptionText { get; set; }

        /// <summary>
        /// toc.forwardLinks Should we create links from the table of content into the actual content? Must be either "true or "false.
        /// </summary>
        [PropertySetting("toc.forwardLinks")]
        public bool? ForwardLinks { get; set; }

        /// <summary>
        /// toc.backLinks Should we link back from the content to this table of content.
        /// </summary>
        [PropertySetting("toc.backLinks")]
        public bool? BackLinks { get; set; }

        /// <summary>
        /// toc.indentation The indentation used for every table of content level, e.g. "2em".
        /// </summary>
        [PropertySetting("toc.indentation")]
        public string? Indentation { get; set; }

        /// <summary>
        /// toc.fontScale How much should we scale down the font for every table of content level? E.g. "0.8"
        /// </summary>
        [PropertySetting("toc.fontScale")]
        public double? FontScale { get; set; }

        /// <summary>
        /// tocXsl If not empty this object is a table of content object, "page" is ignored and this XSL style sheet is used
        /// to convert the outline XML into a table of content.
        /// </summary>
        [PropertySetting("tocXsl")]
        public string? StyleSheet { get; set; }
    }
}
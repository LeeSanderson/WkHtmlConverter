namespace WkHtmlConverter
{
    public class PdfConversionObjectSettings : ISettings
    {
        public TableOfContentSettings? TableOfContent { get; set; }

        /// <summary>
        /// page The URL or path of the web page to convert, if "-" input is read from stdin.
        /// If null then data parameter from <see cref="PdfConverterApiWrapper.AddObject"/> is used. 
        /// </summary>
        [PropertySetting("page")]
        public string? PageUrl { get; set; }

        public HeaderSettings? Header { get; set; }

        public FooterSettings? Footer { get; set; }

        /// <summary>
        /// useExternalLinks Should external links in the HTML document be converted into external pdf links? Must be either "true" or "false.
        /// </summary>
        [PropertySetting("useExternalLinks")]
        public bool? UseExternalLinks { get; set; }

        /// <summary>
        /// useLocalLinks Should internal links in the HTML document be converted into pdf references? Must be either "true" or "false"
        /// </summary>
        [PropertySetting("useLocalLinks")]
        public bool? UseLocalLinks { get; set; }

        /// <summary>
        /// produceForms Should we turn HTML forms into PDF forms? Must be either "true" or file".
        /// </summary>
        [PropertySetting("produceForms")]
        public bool? ProduceForms { get; set; }

        public LoadSettings? LoadSettings { get; set; }
        
        public WebSettings? WebSettings { get; set; }

        /// <summary>
        /// includeInOutline Should the sections from this document be included in the outline and table of content?
        /// </summary>
        [PropertySetting("includeInOutline")]
        public bool? IncludeInOutline { get; set; }

        /// <summary>
        /// pagesCount Should we count the pages of this document, in the counter used for TOC, headers and footers?
        /// </summary>
        [PropertySetting("pagesCount")]
        public bool? PagesCount { get; set; }
    }
}

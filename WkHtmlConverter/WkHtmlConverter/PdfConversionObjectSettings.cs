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
    }
}

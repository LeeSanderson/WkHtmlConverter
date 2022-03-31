namespace WkHtmlConverter
{
    public class PdfConversionGlobalSettings : ISettings
    {
        public PdfPaperSize? PaperSize { get; set; }

        /// <summary>
        /// size.width The with of the output document, e.g. "4cm".
        /// </summary>
        [PropertySetting("size.width")]
        private string? PaperWidth => PaperSize?.Width;

        /// <summary>
        /// size.height The height of the output document, e.g. "12in".
        /// </summary>
        [PropertySetting("size.height")]
        private string? PaperHeight => PaperSize?.Height;
        

    }
}

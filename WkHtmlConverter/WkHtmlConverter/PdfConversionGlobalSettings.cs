namespace WkHtmlConverter
{
    public class PdfConversionGlobalSettings : ISettings
    {
        public PdfPaperSize? PaperSize { get; set; }

        /// <summary>
        /// size.width The with of the output document, e.g. "4cm".
        /// </summary>
        [PropertySetting("size.width")]
        public string? PaperWidth => PaperSize?.Width;

        /// <summary>
        /// size.height The height of the output document, e.g. "12in".
        /// </summary>
        [PropertySetting("size.height")]
        public string? PaperHeight => PaperSize?.Height;

        /// <summary>
        /// orientation The orientation of the output document, must be either "Landscape" or "Portrait".
        /// </summary>
        [PropertySetting("orientation")]
        public PageOrientation? Orientation { get; set; }

        /// <summary>
        /// colorMode Should the output be printed in color or gray scale, must be either "Color" or "Grayscale"
        /// </summary>
        [PropertySetting("colorMode")]
        public ColourMode? ColourMode { get; set; }

        /// <summary>
        /// dpi What dpi should we use when printing, e.g. "80".
        /// </summary>
        [PropertySetting("dpi")]
        public int? Dpi { get; set; }

        /// <summary>
        /// pageOffset A number that is added to all page numbers when printing headers, footers and table of content.
        /// </summary>
        [PropertySetting("pageOffset")]
        public int? PageOffset { get; set; }

        /// <summary>
        /// copies How many copies should we print?. e.g. "2".
        /// </summary>
        [PropertySetting("copies")]
        public int? NumberOfCopies { get; set; }

        /// <summary>
        /// collate Should the copies be collated? Must be either "true" or "false".
        /// </summary>
        [PropertySetting("collate")]
        public bool? Collate { get; set; }

        /// <summary>
        /// outline Should a outline (table of content in the sidebar) be generated and put into the PDF? Must be either "true" or false".
        /// </summary>
        [PropertySetting("outline")]
        public bool? Outline { get; set; }

        /// <summary>
        /// outlineDepth The maximal depth of the outline, e.g. "4".
        /// </summary>
        [PropertySetting("outlineDepth")]
        public int? OutlineDepth { get; set; }

        /// <summary>
        /// dumpOutline If not set to the empty string a XML representation of the outline is dumped to this file.
        /// </summary>
        [PropertySetting("dumpOutline")]
        public string? DumpOutline { get; set; }

        /// <summary>
        /// out The path of the output file, if "-" output is sent to stdout, if empty the output is stored in a buffer.
        /// which can be accessed via <see cref="PdfConverterApiWrapper.GetConversionResult"/>.
        /// </summary>
        [PropertySetting("out")]
        public string? OutputPath { get; set; }

        /// <summary>
        /// documentTitle The title of the PDF document.
        /// </summary>
        [PropertySetting("documentTitle")]
        public string? DocumentTitle { get; set; }

        /// <summary>
        /// useCompression Should we use loss less compression when creating the pdf file? Must be either "true" or "false".
        /// </summary>
        [PropertySetting("useCompression")]
        public bool? UseCompression { get; set; }

        public Margins? Margins { get; set; }

        /// <summary>
        /// margin.top Size of the top margin, e.g. "2cm"
        /// </summary>
        [PropertySetting("margin.top")]
        public string? MarginTop => Margins?.WithUnitsFor(Margins?.Top);

        /// <summary>
        /// margin.bottom Size of the bottom margin, e.g. "2cm"
        /// </summary>
        [PropertySetting("margin.bottom")]
        public string? MarginBottom => Margins?.WithUnitsFor(Margins?.Bottom);

        /// <summary>
        /// margin.left Size of the left margin, e.g. "2cm"
        /// </summary>
        [PropertySetting("margin.left")]
        public string? MarginLeft => Margins?.WithUnitsFor(Margins?.Left);

        /// <summary>
        /// margin.right Size of the right margin, e.g. "2cm"
        /// </summary>
        [PropertySetting("margin.right")]
        public string? MarginRight => Margins?.WithUnitsFor(Margins?.Right);

        /// <summary>
        /// imageDPI The maximal DPI to use for images in the PDF document.
        /// </summary>
        [PropertySetting("imageDPI")]
        public int? ImageDpi { get; set; }

        /// <summary>
        /// imageQuality The JPEG compression factor to use when producing the PDF document, e.g. "92".
        /// </summary>
        [PropertySetting("imageQuality")]
        public int? ImageQuality { get; set; }

        /// <summary>
        /// load.cookieJar Path of file used to load and store cookies.
        /// </summary>
        [PropertySetting("load.cookieJar")]
        public string? CookieJarPath { get; set; }
    }
}

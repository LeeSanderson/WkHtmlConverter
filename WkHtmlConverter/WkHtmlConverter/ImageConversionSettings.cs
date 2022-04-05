namespace WkHtmlConverter
{
    /// <summary>
    /// Settings for image conversion - see https://wkhtmltopdf.org/libwkhtmltox/pagesettings.html#pageImageGlobal
    /// </summary>
    public class ImageConversionSettings : ISettings
    {
        /// <summary>
        /// crop.left left/x coordinate of the window to capture in pixels. E.g. "200"
        /// </summary>
        [PropertySetting("crop.left")]
        public int? CropLeft { get; set; }

        /// <summary>
        /// crop.top top/y coordinate of the window to capture in pixels. E.g. "200"
        /// </summary>
        [PropertySetting("crop.top")]
        public int? CropTop { get; set; }

        /// <summary>
        /// crop.width Width of the window to capture in pixels. E.g. "200"
        /// </summary>
        [PropertySetting("crop.width")]
        public int? CropWidth { get; set; }

        /// <summary>
        /// crop.height Height of the window to capture in pixels. E.g. "200"
        /// </summary>
        [PropertySetting("crop.height")]
        public int? CropHeight { get; set; }

        /// <summary>
        /// load.cookieJar Path of file used to load and store cookies.
        /// </summary>
        [PropertySetting("load.cookieJar")]
        public string? CookieJarPath { get; set; }

        /// <summary>
        /// load.* Page specific settings related to loading content, <see cref="WkHtmlConverter.LoadSettings"/>.
        /// </summary>
        public LoadSettings? LoadSettings { get; set; }

        /// <summary>
        /// web.* Web page specific settings, <see cref="WkHtmlConverter.WebSettings"/>.
        /// </summary>
        public WebSettings? WebSettings { get; set; }

        /// <summary>
        /// transparent When outputting a PNG or SVG, make the white background transparent. Must be either "true" or "false"
        /// </summary>
        [PropertySetting("transparent")]
        public bool? Transparent { get; set; }

        /// <summary>
        /// in The URL or path of the input file, if "-" stdin is used, if null then data parameter from <see cref="ImageConverterApiWrapper.CreateConverter"/> is used. 
        /// E.g. "http://google.com"
        /// </summary>
        [PropertySetting("in")]
        public string? InputUrl { get; set; }

        /// <summary>
        /// out The path of the output file, if "-" stdout is used, if empty the content is stored to a internalBuffer
        /// which can be accessed via <see cref="ImageConverterApiWrapper.GetConversionResult"/>.
        /// </summary>
        [PropertySetting("out")]
        public string? OutputPath { get; set; }

        /// <summary>
        /// fmt The output format to use, must be either "", "jpg", "png", "bmp" or "svg".
        /// </summary>
        [PropertySetting("fmt")]
        public ImageOutputFormat? Format { get; set; }

        /// <summary>
        /// screenWidth The with of the screen used to render is pixels, e.g "800".
        /// </summary>
        [PropertySetting("screenWidth")]
        public int? ScreenWidth { get; set; }

        /// <summary>
        /// smartWidth Should we expand the screenWidth if the content does not fit? must be either "true" or "false".
        /// </summary>
        [PropertySetting("smartWidth")]
        public bool? SmartWidth { get; set; }

        /// <summary>
        /// quality The compression factor to use when outputting a JPEG image. E.g. "94".
        /// </summary>
        [PropertySetting("quality")]
        public int? Quality { get; set; }
    }
}
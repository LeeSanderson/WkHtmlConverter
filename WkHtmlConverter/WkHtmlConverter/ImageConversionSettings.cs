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

    }
}

using System.Collections.Generic;

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
        /// load.* Page specific settings related to loading content, <see cref="LoadSettings"/>.
        /// </summary>
        public LoadSettings? LoadSettings { get; set; }
    }

    public class LoadSettings
    {
        /// <summary>
        /// load.username The user name to use when logging into a website, E.g. "Bart"
        /// </summary>
        [PropertySetting("load.username")]
        public string? Username { get; set; }

        /// <summary>
        /// load.password The password to used when logging into a website, E.g. "password123"
        /// </summary>
        [PropertySetting("load.password")]
        public string? Password { get; set; }

        /// <summary>
        /// load.jsdelay The mount of time in milliseconds to wait after a page has done loading until it is actually printed.
        /// E.g. "1200". We will wait this amount of time or until, JavaScript calls window.print(). Default = 200
        /// </summary>
        [PropertySetting("load.jsdelay")]
        public int? JavaScriptDelay { get; set; }

        /// <summary>
        /// load.zoomFactor How much should we zoom in on the content? E.g. "2.2". Default = 1.0
        /// </summary>
        [PropertySetting("load.zoomFactor")]
        public double? ZoomFactor { get; set; }


        /// <summary>
        /// load.customHeaders Custom headers used when requesting page.
        /// </summary>
        [PropertySetting("load.customHeaders")]
        public Dictionary<string, string>? CustomHeaders { get; set; }
    }
}

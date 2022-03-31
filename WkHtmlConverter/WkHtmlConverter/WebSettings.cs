namespace WkHtmlConverter
{
    public class WebSettings : ISettings
    {
        /// <summary>
        /// web.background Should we print the background? Must be either "true" or "false".
        /// </summary>
        [PropertySetting("web.background")]
        public bool? PrintBackground { get; set; }

        /// <summary>
        /// web.loadImages Should we load images? Must be either "true" or "false".
        /// </summary>
        [PropertySetting("web.loadImages")]
        public bool? LoadImages { get; set; }

        /// <summary>
        /// web.enableJavascript Should we enable JavaScript? Must be either "true" or "false".
        /// </summary>
        [PropertySetting("web.enableJavascript")]
        public bool? EnableJavascript { get; set; }

        /// <summary>
        /// web.enableIntelligentShrinking Should we enable intelligent shrinking to fit more content on one page?
        /// Must be either "true" or "false". Has no effect for wkhtmltoimage.
        /// </summary>
        [PropertySetting("web.enableIntelligentShrinking")]
        public bool? EnableIntelligentShrinking { get; set; }

        /// <summary>
        /// web.minimumFontSize The minimum font size allowed. E.g. "9"
        /// </summary>
        [PropertySetting("web.minimumFontSize")]
        public int? MinimumFontSize { get; set; }

        /// <summary>
        /// web.defaultEncoding What encoding should we guess content is using if they do not specify it properly? E.g. "utf-8"
        /// </summary>
        [PropertySetting("web.defaultEncoding")]
        public string? DefaultEncoding { get; set; }

        /// <summary>
        ///web.userStyleSheet Url er path to a user specified style sheet.
        /// </summary>
        [PropertySetting("web.userStyleSheet")]
        public string? UserStyleSheet { get; set; }

        /// <summary>
        /// web.enablePlugins Should we enable NS plug-ins, must be either "true" or "false". Enabling this will have limited success.
        /// </summary>
        [PropertySetting("web.enablePlugins")]
        public bool? EnablePlugins { get; set; }
    }
}
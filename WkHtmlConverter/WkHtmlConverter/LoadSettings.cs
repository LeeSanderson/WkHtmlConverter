using System.Collections.Generic;

namespace WkHtmlConverter
{
    public class LoadSettings : ISettings
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

        /// <summary>
        /// load.repeatCustomHeaders Should the custom headers be sent all elements loaded instead of only the main page? Must be either "true" or "false".
        /// </summary>
        [PropertySetting("load.repeatCustomHeaders")]
        public bool? RepeatCustomerHeaders { get; set; }

        /// <summary>
        /// load.cookies Cookies used when requesting page.
        /// </summary>
        [PropertySetting("load.cookies")]
        public Dictionary<string, string>? Cookies { get; set; }

        /// <summary>
        /// load.blockLocalFileAccess Disallow local and piped files to access other local files. Must be either "true" or "false".
        /// </summary>
        [PropertySetting("load.blockLocalFileAccess")]
        public bool? BlockLocalFileAccess { get; set; }

        /// <summary>
        /// load.stopSlowScript Stop slow running JavaScript. Must be either "true" or "false".
        /// </summary>
        [PropertySetting("load.stopSlowScript")]
        public bool? StopSlowScript { get; set; }

        /// <summary>
        /// load.debugJavascript Forward JavaScript warnings and errors to the warning callback. Must be either "true" or "false".
        /// </summary>
        [PropertySetting("load.debugJavascript")]
        public bool? DebugJavaScript { get; set; }

        /// <summary>
        /// load.loadErrorHandling How should we handle objects that fail to load.Must be one of:
        ///   "abort" Abort the conversion process
        ///   "skip" Do not add the object to the final output
        ///   "ignore" Try to add the object to the final output.
        /// </summary>
        [PropertySetting("load.loadErrorHandling")]
        public LoadErrorHandling? LoadErrorHandling { get; set; }

        /// <summary>
        /// load.proxy String describing what proxy to use when loading the object.
        /// </summary>
        [PropertySetting("load.proxy")]
        public string? Proxy { get; set; }

        /// <summary>
        /// load.printMediaType Should the content be printed using the print media type instead of the screen media type.
        /// Must be either "true" or "false". Has no effect for wkhtmltoimage.
        /// </summary>
        [PropertySetting("load.printMediaType")]
        public bool? ForcePrintMediaType { get; set; }
    }
}
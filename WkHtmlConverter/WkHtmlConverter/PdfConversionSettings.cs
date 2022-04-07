using System.Collections.Generic;

namespace WkHtmlConverter
{
    public class PdfConversionSettings
    {
        public PdfConversionGlobalSettings GlobalSettings { get; set; } = new();

        public List<PdfConversionObjectSettings> Sections { get; set; } = new();
    }
}

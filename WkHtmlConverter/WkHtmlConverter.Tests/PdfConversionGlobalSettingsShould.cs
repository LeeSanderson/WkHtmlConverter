using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace WkHtmlConverter.Tests
{
    public class PdfConversionGlobalSettingsShould
    {
        [Fact]
        public void ConvertToExpectedSettingsStringsWhenApplied()
        {
            var appliedSettings = new List<KeyValuePair<string, string?>>();
            var settingsApplier = new SettingsApplier((key, value) => appliedSettings.Add(new KeyValuePair<string, string?>(key, value)));
            var globalSettings = new PdfConversionGlobalSettings
            {
                PaperSize = PdfPaperKind.A4,
                Orientation = PageOrientation.Landscape,
                ColourMode = ColourMode.Grayscale,
                Dpi = 300,
                PageOffset = 9,
                NumberOfCopies = 2,
                Collate = true,
                Outline = true,
                OutlineDepth = 4,
                DumpOutline = "outlineDump.xml",
                OutputPath = "out.pdf",
                DocumentTitle = "The Title",
                UseCompression = true,
                Margins = new Margins { Top = 10, Bottom = 15, Left = 5, Right = 20, Units = MarginUnits.Millimeters},
                ImageDpi = 72,
                ImageQuality = 92,
                CookieJarPath = "cookies.txt"
            };

            settingsApplier.Apply(globalSettings);

            appliedSettings
                .Should()
                .Contain("size.width", "210mm")
                .And.Contain("size.height", "297mm")
                .And.Contain("orientation", "landscape")
                .And.Contain("colorMode", "grayscale")
                .And.Contain("dpi", "300")
                .And.Contain("pageOffset", "9")
                .And.Contain("copies", "2")
                .And.Contain("collate", "true")
                .And.Contain("outline", "true")
                .And.Contain("outlineDepth", "4")
                .And.Contain("dumpOutline", "outlineDump.xml")
                .And.Contain("out", "out.pdf")
                .And.Contain("documentTitle", "The Title")
                .And.Contain("useCompression", "true")
                .And.Contain("margin.top", "10mm")
                .And.Contain("margin.bottom", "15mm")
                .And.Contain("margin.left", "5mm")
                .And.Contain("margin.right", "20mm")
                .And.Contain("imageDPI", "72")
                .And.Contain("imageQuality", "92")
                .And.Contain("load.cookieJar", "cookies.txt");
        }
    }
}

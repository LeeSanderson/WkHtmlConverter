using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using VerifyTests;
using VerifyXunit;
using Xunit;

namespace WkHtmlConverter.Tests
{
    public class HtmlToPdfConverterShould : VerifyBase
    {
        public HtmlToPdfConverterShould() : base()
        {
        }

        static HtmlToPdfConverterShould()
        {
            VerifyDocNet.Initialize();
            VerifyImageMagick.RegisterComparers(threshold: 0.13, ImageMagick.ErrorMetric.PerceptualHash);
        }

        [Fact]
        public async Task CreateExpectedPdfFromHtml()
        {
            const string generatedImageFileName = $"{nameof(CreateExpectedPdfFromHtml)}.pdf";
            var converter = new HtmlToPdfConverter();
            var pdfConversionSettings = new PdfConversionSettings
            {
                GlobalSettings = new PdfConversionGlobalSettings(),
                Sections = new List<PdfConversionObjectSettings>
                {
                    new()
                }
            };

            var result = await converter.ConvertAsync(pdfConversionSettings, "<h1>Hello World</h1>");

            result.Length.Should().BeGreaterThan(0);
            await File.WriteAllBytesAsync(generatedImageFileName, result);
            await VerifyFile(generatedImageFileName);
        }

    }
}

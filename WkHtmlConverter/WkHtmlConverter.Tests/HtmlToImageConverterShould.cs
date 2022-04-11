using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using VerifyTests;
using VerifyXunit;
using Xunit;

namespace WkHtmlConverter.Tests
{
    public class HtmlToImageConverterShould : VerifyBase
    {
        public HtmlToImageConverterShould(): base()
        {
        }

        static HtmlToImageConverterShould()
        {
            VerifyImageSharp.Initialize();
        }

        [UIFact]
        public Task CreateExpectedImageFromHtml()
        {
            const string generatedImageFileName = $"{nameof(CreateExpectedImageFromHtml)}.png";
            var converter = new HtmlToImageConverter();

            var result = converter.Convert(new ImageConversionSettings { Format = ImageOutputFormat.Png }, "<h1>Hello World</h1>");

            result.Length.Should().BeGreaterThan(0);
            File.WriteAllBytes(generatedImageFileName, result);
            return VerifyFile(generatedImageFileName);
        }
    }
}

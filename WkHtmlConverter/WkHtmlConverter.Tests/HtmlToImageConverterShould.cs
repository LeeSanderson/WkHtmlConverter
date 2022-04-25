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

        [Fact]
        public async Task CreateExpectedImageFromHtml()
        {
            const string generatedImageFileName = $"{nameof(CreateExpectedImageFromHtml)}.png";
            var converter = new HtmlToImageConverter();

            var result = await converter.ConvertAsync(new ImageConversionSettings { Format = ImageOutputFormat.Png }, "<h1>Hello World</h1>");

            result.Length.Should().BeGreaterThan(0);
            await File.WriteAllBytesAsync(generatedImageFileName, result);
            await VerifyFile(generatedImageFileName);
        }

        [Fact]
        public async Task CreateExpectedImageFromHtmlInMultiThreadedEnvironment()
        {
            const string generatedImageFileName1 = $"{nameof(CreateExpectedImageFromHtmlInMultiThreadedEnvironment)}_1.png";
            const string generatedImageFileName2 = $"{nameof(CreateExpectedImageFromHtmlInMultiThreadedEnvironment)}_2.png";

            var tasks = new[]
            {
                Task.Run(() => DoConvert(new HtmlToImageConverter(), generatedImageFileName1)), 
                Task.Run(() => DoConvert(new HtmlToImageConverter(), generatedImageFileName2))
            };


            await Task.WhenAll(tasks);
            
            await VerifyFile(generatedImageFileName1).UseMethodName($"{nameof(CreateExpectedImageFromHtmlInMultiThreadedEnvironment)}_1");
            await VerifyFile(generatedImageFileName2).UseMethodName($"{nameof(CreateExpectedImageFromHtmlInMultiThreadedEnvironment)}_2");
        }

        [Fact]
        public async Task CreateExpectedImageContainingUserAgentFromHtml()
        {
            const string generatedImageFileName = $"{nameof(CreateExpectedImageFromHtml)}.jpg";
            var converter = new HtmlToImageConverter();

            var result = await converter.ConvertAsync(new ImageConversionSettings { Format = ImageOutputFormat.Jpg }, "<script>document.write(navigator.userAgent)</script>");

            result.Length.Should().BeGreaterThan(0);
            await File.WriteAllBytesAsync(generatedImageFileName, result);
            await VerifyFile(generatedImageFileName);
        }

        private static async Task DoConvert(HtmlToImageConverter converter, string generatedImageFileName)
        {
            var result = await converter.ConvertAsync(new ImageConversionSettings { Format = ImageOutputFormat.Png }, $"<h1>Hello from file {generatedImageFileName}</h1>");

            result.Length.Should().BeGreaterThan(0);
            await File.WriteAllBytesAsync(generatedImageFileName, result);
        }
    }
}

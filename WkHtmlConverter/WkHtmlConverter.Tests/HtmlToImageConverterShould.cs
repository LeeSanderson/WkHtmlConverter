using FluentAssertions;
using Xunit;

namespace WkHtmlConverter.Tests
{
    public class HtmlToImageConverterShould
    {
        [UIFact]
        public void CreateExpectedImageFromHtml()
        {
            var converter = new HtmlToImageConverter();
            var result = converter.Convert(new ImageConversionSettings { Format = ImageOutputFormat.Png }, "<h1>Hello World</h1>");


            result.Length.Should().BeGreaterThan(0);
        }
    }
}

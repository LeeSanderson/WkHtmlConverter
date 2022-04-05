using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace WkHtmlConverter.Tests
{
    public class ImageConversionSettingsShould
    {
        [Fact]
        public void ConvertToExpectedSettingsStringsWhenApplied()
        {
            var appliedSettings = new List<KeyValuePair<string, string?>>();
            var settingsApplier = new SettingsApplier((key, value) => appliedSettings.Add(new KeyValuePair<string, string?>(key, value)));
            var imageConversionSettings = new ImageConversionSettings
            {
                CropLeft = 100,
                CropHeight = 200,
                CropTop = 50,
                CropWidth = 250,
                CookieJarPath = "cookies.txt",
                Format = ImageOutputFormat.Png,
                InputUrl = "https://www.sixsideddice.com",
                LoadSettings = null,
                OutputPath = "output.png",
                Quality = 100,
                ScreenWidth = 840,
                SmartWidth = true,
                Transparent = true,
                WebSettings = null
            };

            settingsApplier.Apply(imageConversionSettings);

            appliedSettings
                .Should()
                .Contain("crop.left", "100")
                .And.Contain("crop.top", "50")
                .And.Contain("crop.width", "250")
                .And.Contain("crop.height", "200")
                .And.Contain("load.cookieJar", "cookies.txt")
                .And.Contain("transparent", "true")
                .And.Contain("in", "https://www.sixsideddice.com")
                .And.Contain("out", "output.png")
                .And.Contain("fmt", "png")
                .And.Contain("screenWidth", "840")
                .And.Contain("smartWidth", "true")
                .And.Contain("quality", "100");
        }
    }
}

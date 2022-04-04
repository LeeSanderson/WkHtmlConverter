using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace WkHtmlConverter.Tests
{
    public class WebSettingsShould
    {
        [Fact]
        public void ConvertToExpectedSettingsStringsWhenApplied()
        {
            var  appliedSettings = new List<KeyValuePair<string, string?>>();
            var settingsApplier = new SettingsApplier((key, value) => appliedSettings.Add(new KeyValuePair<string, string?>(key, value)));
            var webSettings = new WebSettings
            {
                DefaultEncoding = "UTF-8",
                EnableIntelligentShrinking = true,
                EnablePlugins = true,
                EnableJavascript = true,
                LoadImages = true,
                MinimumFontSize = 12,
                PrintBackground = true,
                UserStyleSheet = "styles.css"
            };

            settingsApplier.Apply(webSettings);

            appliedSettings
                .Should()
                .Contain("web.background", "true")
                .And.Contain("web.loadImages", "true")
                .And.Contain("web.enableJavascript", "true")
                .And.Contain("web.enableIntelligentShrinking", "true")
                .And.Contain("web.minimumFontSize", "12")
                .And.Contain("web.defaultEncoding", "UTF-8")
                .And.Contain("web.userStyleSheet", "styles.css")
                .And.Contain("web.enablePlugins", "true");
        }
    }
}

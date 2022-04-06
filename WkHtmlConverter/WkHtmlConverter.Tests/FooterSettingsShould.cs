using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace WkHtmlConverter.Tests
{
    public class FooterSettingsShould
    {
        [Fact]
        public void ConvertToExpectedSettingsStringsWhenApplied()
        {
            var appliedSettings = new List<KeyValuePair<string, string?>>();
            var settingsApplier = new SettingsApplier((key, value) => appliedSettings.Add(new KeyValuePair<string, string?>(key, value)));
            var footerSettings = new FooterSettings()
            {
                FontSize = 13,
                FontName = "times",
                Left = "Left Text",
                Center = "Center Text",
                Right = "Right Text",
                Line = true,
                Spacing = 1.8,
                Url = "footer.html"
            };

            settingsApplier.Apply(footerSettings);

            appliedSettings
                .Should()
                .Contain("footer.fontSize", "13")
                .And.Contain("footer.fontName", "times")
                .And.Contain("footer.left", "Left Text")
                .And.Contain("footer.center", "Center Text")
                .And.Contain("footer.right", "Right Text")
                .And.Contain("footer.line", "true")
                .And.Contain("footer.spacing", "1.8")
                .And.Contain("footer.htmlUrl", "footer.html");
        }
    }
}
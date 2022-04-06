using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace WkHtmlConverter.Tests
{
    public class HeaderSettingsShould
    {
        [Fact]
        public void ConvertToExpectedSettingsStringsWhenApplied()
        {
            var appliedSettings = new List<KeyValuePair<string, string?>>();
            var settingsApplier = new SettingsApplier((key, value) => appliedSettings.Add(new KeyValuePair<string, string?>(key, value)));
            var headerSettings = new HeaderSettings()
            {
                FontSize = 13,
                FontName = "times",
                Left = "Left Text",
                Center = "Center Text",
                Right = "Right Text",
                Line = true,
                Spacing = 1.8,
                Url = "header.html"
            };

            settingsApplier.Apply(headerSettings);

            appliedSettings
                .Should()
                .Contain("header.fontSize", "13")
                .And.Contain("header.fontName", "times")
                .And.Contain("header.left", "Left Text")
                .And.Contain("header.center", "Center Text")
                .And.Contain("header.right", "Right Text")
                .And.Contain("header.line", "true")
                .And.Contain("header.spacing", "1.8")
                .And.Contain("header.htmlUrl", "header.html");
        }
    }
}
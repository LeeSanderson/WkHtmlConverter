using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace WkHtmlConverter.Tests
{
    public class TableOfContentSettingsShould
    {
        [Fact]
        public void ConvertToExpectedSettingsStringsWhenApplied()
        {
            var appliedSettings = new List<KeyValuePair<string, string?>>();
            var settingsApplier = new SettingsApplier((key, value) => appliedSettings.Add(new KeyValuePair<string, string?>(key, value)));
            var tableOfContentSettings = new TableOfContentSettings
            {
                UseDottedLines = true,
                CaptionText = "TOC Caption Text",
                ForwardLinks = true,
                BackLinks = true,
                Indentation = "2em",
                FontScale = 0.8,
                StyleSheet = "style.xsl"
            };

            settingsApplier.Apply(tableOfContentSettings);

            appliedSettings
                .Should()
                .Contain("toc.useDottedLines", "true")
                .And.Contain("toc.captionText", "TOC Caption Text")
                .And.Contain("toc.forwardLinks", "true")
                .And.Contain("toc.backLinks", "true")
                .And.Contain("toc.indentation", "2em")
                .And.Contain("toc.fontScale", "0.8")
                .And.Contain("tocXsl", "style.xsl");
        }
    }
}

using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace WkHtmlConverter.Tests
{
    public class PdfConversionObjectSettingsShould
    {
        [Fact]
        public void ConvertToExpectedSettingsStringsWhenApplied()
        {
            var appliedSettings = new List<KeyValuePair<string, string?>>();
            var settingsApplier = new SettingsApplier((key, value) => appliedSettings.Add(new KeyValuePair<string, string?>(key, value)));
            var objectSettings = new PdfConversionObjectSettings
            {
                TableOfContent = new() { StyleSheet = "toc.xsl" },
                PageUrl = "https://www.sixsideddice.com",
                Header = new() { Left = "Header Left Text" },
                Footer = new() { Right = "Footer Right Text" },
                UseExternalLinks = true,
                UseLocalLinks = true,
                ProduceForms = true,
                LoadSettings = new() { JavaScriptDelay = 1000 },
                WebSettings = new() { DefaultEncoding = "utf8"},
                IncludeInOutline = true,
                PagesCount = true
            };

            settingsApplier.Apply(objectSettings);

            appliedSettings
                .Should()
                .Contain("page", "https://www.sixsideddice.com")
                .And.Contain("header.left", "Header Left Text")
                .And.Contain("footer.right", "Footer Right Text")
                .And.Contain("useExternalLinks", "true")
                .And.Contain("useLocalLinks", "true")
                .And.Contain("produceForms", "true")
                .And.Contain("load.jsdelay", "1000")
                .And.Contain("web.defaultEncoding", "utf8")
                .And.Contain("includeInOutline", "true")
                .And.Contain("pagesCount", "true")
                .And.Contain("tocXsl", "toc.xsl");
        }
    }
}

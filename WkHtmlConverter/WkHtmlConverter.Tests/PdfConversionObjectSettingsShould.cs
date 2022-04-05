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
            };

            settingsApplier.Apply(objectSettings);

            appliedSettings
                .Should()
                .Contain("size.width", "210mm")
                .And.Contain("load.cookieJar", "cookies.txt");
        }
    }
}

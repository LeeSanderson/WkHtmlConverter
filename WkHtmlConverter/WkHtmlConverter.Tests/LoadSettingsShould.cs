using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace WkHtmlConverter.Tests
{
    public class LoadSettingsShould
    {
        [Fact]
        public void ConvertToExpectedSettingsStringsWhenApplied()
        {
            var appliedSettings = new List<KeyValuePair<string, string?>>();
            var settingsApplier = new SettingsApplier((key, value) => appliedSettings.Add(new KeyValuePair<string, string?>(key, value)));
            var loadSettings = new LoadSettings
            {
                BlockLocalFileAccess = true,
                Cookies = new() { { "x-cookie", "token" } },
                CustomHeaders = new() { { "x-header", "header-value" } },
                DebugJavaScript = true,
                ForcePrintMediaType = true,
                JavaScriptDelay = 1000,
                LoadErrorHandling = LoadErrorHandling.Ignore,
                Password = "password123",
                Proxy = "https://192.168.1.10:9999",
                RepeatCustomerHeaders = true,
                StopSlowScript = true,
                Username = "User name",
                ZoomFactor = 2
            };

            settingsApplier.Apply(loadSettings);

            appliedSettings
                .Should()
                .Contain("load.username", "User name")
                .And.Contain("load.password", "password123")
                .And.Contain("load.jsdelay", "1000")
                .And.Contain("load.zoomFactor", "2")
                .And.Contain("load.customHeaders.append", null)
                .And.Contain("load.customHeaders[0]", "x-header\nheader-value")
                .And.Contain("load.repeatCustomHeaders", "true")
                .And.Contain("load.cookies.append", null)
                .And.Contain("load.cookies[0]", "x-cookie\ntoken")
                .And.Contain("load.blockLocalFileAccess", "true")
                .And.Contain("load.stopSlowScript", "true")
                .And.Contain("load.debugJavascript", "true")
                .And.Contain("load.loadErrorHandling", "ignore")
                .And.Contain("load.proxy", "https://192.168.1.10:9999")
                .And.Contain("load.printMediaType", "true");
        }
    }
}

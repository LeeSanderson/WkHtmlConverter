using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace WkHtmlConverter.Tests
{
    public class SettingsApplierShould
    {
        private readonly SettingsApplier _settingsApplier;
        private readonly Dictionary<string, string> _appliedSettings = new();

        public SettingsApplierShould()
        {
            _settingsApplier = new SettingsApplier((key, value) => _appliedSettings.Add(key, value));
        }

        [Fact]
        public void ApplyBooleanSettingAsTrue()
        {
            _settingsApplier.ApplySetting("bool.setting", true);

            _appliedSettings.Should().Contain("bool.setting", "true");
        }
    }
}
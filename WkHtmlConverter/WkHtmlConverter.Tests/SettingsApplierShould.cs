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
            _settingsApplier.Apply("bool.setting", true);

            _appliedSettings.Should().Contain("bool.setting", "true");
        }

        [Fact]
        public void ApplyBooleanSettingAsFalse()
        {
            _settingsApplier.Apply("bool.setting", false);

            _appliedSettings.Should().Contain("bool.setting", "false");
        }

        [Fact]
        public void RoundDoubleSettingTo2DecimalPlaces()
        {
            _settingsApplier.Apply("double.setting", 1.2345);

            _appliedSettings.Should().Contain("double.setting", "1.23");
        }

        [Fact]
        public void ProcessNonNullPropertiesToCreateSettings()
        {
            _settingsApplier.Apply(new ImageConversionSettings() { CropLeft = 200 });

            _appliedSettings.Should().Contain("crop.left", "200");
            _appliedSettings.Count.Should().Be(1);
        }
    }
}
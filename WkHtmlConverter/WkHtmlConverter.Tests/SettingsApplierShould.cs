using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace WkHtmlConverter.Tests
{
    public class SettingsApplierShould
    {
        private readonly SettingsApplier _settingsApplier;
        private readonly List<KeyValuePair<string, string?>> _appliedSettings = new();

        public SettingsApplierShould()
        {
            _settingsApplier = new SettingsApplier((key, value) => _appliedSettings.Add(new KeyValuePair<string, string?>(key, value)));
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
            _settingsApplier.Apply(new ImageConversionSettings { CropLeft = 200 });

            _appliedSettings.Should().Contain("crop.left", "200").And.Contain("fmt", "png");
            _appliedSettings.Count.Should().Be(2);
        }

        [Fact]
        public void ApplyDictionarySettings()
        {
            _settingsApplier.Apply("dictionary_setting",
                new Dictionary<string, string> {{"one", "1"}, {"two", "2"}, {"three", "3"}});

            _appliedSettings.Should().ContainInOrder(
                new KeyValuePair<string, string?>("dictionary_setting.append", null),
                new KeyValuePair<string, string?>("dictionary_setting[0]","one\n1"),
                new KeyValuePair<string, string?>("dictionary_setting.append", null),
                new KeyValuePair<string, string?>("dictionary_setting[1]", "two\n2"),
                new KeyValuePair<string, string?>("dictionary_setting.append", null),
                new KeyValuePair<string, string?>("dictionary_setting[2]", "three\n3"));
        }

        [Fact]
        public void ApplyEnumSettingsAsLowercase()
        {
            _settingsApplier.Apply("enum.setting", LoadErrorHandling.Ignore);

            _appliedSettings.Should().Contain("enum.setting", "ignore");
        }

    }
}
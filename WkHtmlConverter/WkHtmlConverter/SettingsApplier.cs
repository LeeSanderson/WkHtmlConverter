using System;

namespace WkHtmlConverter
{
    public class SettingsApplier
    {
        private readonly Action<string, string> _settingsAction;

        public SettingsApplier(Action<string, string> settingsAction)
        {
            _settingsAction = settingsAction;
        }


        public void ApplySetting(string name, bool value) => _settingsAction(name, value ? "true" : "false");
    }
}

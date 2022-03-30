using System;
using System.Collections.Generic;
using System.Reflection;

namespace WkHtmlConverter
{
    public class SettingsApplier
    {
        private readonly Action<string, string?> _settingsAction;

        public SettingsApplier(Action<string, string?> settingsAction)
        {
            _settingsAction = settingsAction;
        }


        public void Apply(string name, bool value) => _settingsAction(name, value ? "true" : "false");

        public void Apply(string name, double value) => _settingsAction(name, value.ToString("0.##"));

        public void Apply(string name, string value) => _settingsAction(name, value);

        public void Apply(string name, IEnumerable<KeyValuePair<string, string>> values)
        {
            // See https://github.com/wkhtmltopdf/wkhtmltopdf/blob/master/src/lib/reflect.hh#192 for list/dictionary ".append" implementation
            // AND https://github.com/wkhtmltopdf/wkhtmltopdf/blob/master/src/lib/reflect.hh#148 for QPair<QString, QString> parsing 
            int index = 0;
            foreach (var value in values)
            {
                _settingsAction($"{name}.append", null);
                _settingsAction($"{name}[{index}]", $"{value.Key}\n{value.Value}");
                index++;
            }
        }

        public void Apply(ISettings settings)
        {
            var properties = settings.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var property in properties)
            {
                var value = property.GetValue(settings);
                if (value != null)
                {
                    if (value.GetType().IsAssignableFrom(typeof(ISettings)))
                    {
                        Apply((ISettings)value);
                    }
                    else
                    {
                        var settingAttribute = property.GetCustomAttribute<PropertySettingAttribute>();
                        if (settingAttribute != null)
                        {
                            InternalApply(settingAttribute.Name, value);
                        }
                    }
                }
            }
        }

        private void InternalApply(string name, object value)
        {
            switch (value)
            {
                case bool boolValue:
                    Apply(name, boolValue);
                    break;
                case double doubleValue:
                    Apply(name, doubleValue);
                    break;
                case IEnumerable<KeyValuePair<string, string>> dictionaryValues:
                    Apply(name, dictionaryValues);
                    break;
                default:
                    Apply(name, value.ToString());
                    break;
            }
        }
    }
}

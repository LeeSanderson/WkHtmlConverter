using System;

namespace WkHtmlConverter
{
    public class PropertySettingAttribute : Attribute
    {
        public PropertySettingAttribute(string name)
        {
            Name = name;
        }

        public string Name { get;  }
    }
}
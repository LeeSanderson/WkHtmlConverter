using System;

namespace WkHtmlConverter
{
    public class ConverterFinishedEventArgs : EventArgs
    {
        public bool ConversionSuccessful { get; set; }
    }
}
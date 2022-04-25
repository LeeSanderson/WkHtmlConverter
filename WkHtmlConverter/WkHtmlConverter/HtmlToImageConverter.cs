using System;

namespace WkHtmlConverter
{
    public class HtmlToImageConverter : HtmlConverterBase<ImageConversionSettings>
    {
        private readonly ImageConverterApiWrapper _api;

        public HtmlToImageConverter()
        {
            _api = new ImageConverterApiWrapper();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _api.Dispose();
            }
        }

        protected override string GetCurrentPhaseDescription(IntPtr converter, int currentPhase) =>
            _api.GetCurrentPhaseDescription(converter, currentPhase);

        protected override int GetPhaseCount(IntPtr converter) => _api.GetPhaseCount(converter);

        protected override int GetCurrentPhase(IntPtr converter) => _api.GetCurrentPhase(converter);

        protected override byte[] InternalConvert(ImageConversionSettings settings, string? html)
        {
            _api.Load();

            var globalSettingsPtr = _api.CreateGlobalSettings();
            var settingsApplier =
                new SettingsApplier(((name, value) => _api.SetGlobalSetting(globalSettingsPtr, name, value)));
            settingsApplier.Apply(settings);

            var converterPtr = _api.CreateConverter(globalSettingsPtr, html);
            try
            {
                _api.SetWarningCallback(converterPtr, OnWarning);
                _api.SetErrorCallback(converterPtr, OnError);
                _api.SetFinishedCallback(converterPtr, OnFinished);
                _api.SetProgressChangedCallback(converterPtr, OnProgress);
                _api.SetPhaseChangedCallback(converterPtr, OnPhaseChanged);


                if (_api.Convert(converterPtr))
                {
                    return _api.GetConversionResult(converterPtr);
                }

                return Array.Empty<byte>();
            }
            finally
            {
                _api.DestroyConverter(converterPtr);
            }
        }
    }
}

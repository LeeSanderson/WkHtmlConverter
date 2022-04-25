using System;

namespace WkHtmlConverter
{
    public class HtmlToPdfConverter : HtmlConverterBase<PdfConversionSettings>
    {
        private readonly PdfConverterApiWrapper _api;

        public HtmlToPdfConverter()
        {
            _api = new PdfConverterApiWrapper();
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

        protected override byte[] InternalConvert(PdfConversionSettings settings, string? html)
        {
            _api.Load();

            var globalSettingsPtr = _api.CreateGlobalSettings();
            var globalSettingsApplier =
                new SettingsApplier(((name, value) => _api.SetGlobalSetting(globalSettingsPtr, name, value)));
            globalSettingsApplier.Apply(settings.GlobalSettings);

            var converterPtr = _api.CreateConverter(globalSettingsPtr);
            try
            {
                _api.SetWarningCallback(converterPtr, OnWarning);
                _api.SetErrorCallback(converterPtr, OnError);
                _api.SetFinishedCallback(converterPtr, OnFinished);
                _api.SetProgressChangedCallback(converterPtr, OnProgress);
                _api.SetPhaseChangedCallback(converterPtr, OnPhaseChanged);

                foreach (var settingsSection in settings.Sections)
                {
                    var objectSettingsPtr = _api.CreateObjectSettings();
                    var objectSettingsApplier = new SettingsApplier((name, value) =>
                        _api.SetObjectSettings(objectSettingsPtr, name, value));
                    objectSettingsApplier.Apply(settingsSection);

                    _api.AddObject(converterPtr, objectSettingsPtr, html);
                    html = null; // Only apply html to first section.
                }

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

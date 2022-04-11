using System;

namespace WkHtmlConverter
{
    public class HtmlToImageConverter : IDisposable
    {
        private readonly ImageConverterApiWrapper _api;

        public HtmlToImageConverter()
        {
            WkLibraryLoader.Instance.Initialize();
            _api = new ImageConverterApiWrapper();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _api.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public byte[] Convert(ImageConversionSettings settings, string html)
        {
            _api.Load();

            var globalSettingsPtr = _api.CreateGlobalSettings();
                var settingsApplier =
                    new SettingsApplier(((name, value) => _api.SetGlobalSetting(globalSettingsPtr, name, value)));
            settingsApplier.Apply(settings);

            var converterPtr = _api.CreateConverter(globalSettingsPtr, html);
            try
            {
                _api.SetWarningCallback(converterPtr, (_, str) => LogCallBack("Warn", str));
                _api.SetErrorCallback(converterPtr, (_, str) => LogCallBack("Error", str));
                _api.SetFinishedCallback(converterPtr, (_, status) => LogCallBack("Finished", $"Finished with status {status}"));
                _api.SetProgressChangedCallback(converterPtr, (_, progress) => LogCallBack("Progress", $"{progress}% completed"));
                _api.SetPhaseChangedCallback(converterPtr, _ => LogCallBack("Phase", _api.GetCurrentPhaseDescription(converterPtr, _api.GetCurrentPhase(converterPtr))));


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

        private void LogCallBack(string severity, string message)
        {
            Console.WriteLine($"{severity}: {message}");
        }
    }
}

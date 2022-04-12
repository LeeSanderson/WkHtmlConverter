using System;
using System.ComponentModel;

namespace WkHtmlConverter
{
    public class HtmlToImageConverter : IDisposable
    {
        private readonly ImageConverterApiWrapper _api;

        public event EventHandler<MessageEventArgs>? Warning;
        public event EventHandler<MessageEventArgs>? Error;
        public event EventHandler<ConverterFinishedEventArgs>? Finished;
        public event EventHandler<ProgressChangedEventArgs>? Progress;
        public event EventHandler<PhaseChangedEventArgs>? PhaseChanged;

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

        private void OnPhaseChanged(IntPtr converter)
        {
            var currentPhase = _api.GetCurrentPhase(converter);
            PhaseChanged?.Invoke(this,
                new PhaseChangedEventArgs(
                    currentPhase,
                    _api.GetPhaseCount(converter),
                    _api.GetCurrentPhaseDescription(converter, currentPhase)));
        }

        private void OnProgress(IntPtr converter, int progressPercentage) =>
            Progress?.Invoke(this, new ProgressChangedEventArgs(progressPercentage, null));

        private void OnFinished(IntPtr converter, int status) =>
            Finished?.Invoke(this, new ConverterFinishedEventArgs {ConversionSuccessful = status == 1});

        private void OnError(IntPtr converter, string message) =>  Error?.Invoke(this, new MessageEventArgs(message));

        private void OnWarning(IntPtr converter, string message) => Warning?.Invoke(this, new MessageEventArgs(message));
        

        private void LogCallBack(string severity, string message)
        {
            Console.WriteLine($"{severity}: {message}");
        }
    }
}

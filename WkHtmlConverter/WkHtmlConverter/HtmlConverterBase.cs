using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace WkHtmlConverter
{
    public abstract class HtmlConverterBase<TSettings> : IDisposable
        where TSettings : ISettings
    {
        public event EventHandler<MessageEventArgs>? Warning;
        public event EventHandler<MessageEventArgs>? Error;
        public event EventHandler<ConverterFinishedEventArgs>? Finished;
        public event EventHandler<ProgressChangedEventArgs>? Progress;
        public event EventHandler<PhaseChangedEventArgs>? PhaseChanged;

        protected HtmlConverterBase()
        {
            WkLibraryLoader.Instance.Initialize();
        }

        protected virtual void Dispose(bool disposing)
        {
            // Allow subclasses to dispose of resources
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<byte[]> ConvertAsync(TSettings settings, string? html)
        {
            return await WkConversionExecutor.Instance.Queue(() => InternalConvert(settings, html)).ConfigureAwait(false);
        }

        protected abstract byte[] InternalConvert(TSettings settings, string? html);

        protected abstract string GetCurrentPhaseDescription(IntPtr converter, int currentPhase);

        protected abstract int GetPhaseCount(IntPtr converter);

        protected abstract int GetCurrentPhase(IntPtr converter);

        protected void OnPhaseChanged(IntPtr converter)
        {
            var currentPhase = GetCurrentPhase(converter);
            PhaseChanged?.Invoke(this,
                new PhaseChangedEventArgs(
                    currentPhase,
                    GetPhaseCount(converter),
                    GetCurrentPhaseDescription(converter, currentPhase)));
        }

        protected void OnProgress(IntPtr converter, int progressPercentage) =>
            Progress?.Invoke(this, new ProgressChangedEventArgs(progressPercentage, null));

        protected void OnFinished(IntPtr converter, int status) =>
            Finished?.Invoke(this, new ConverterFinishedEventArgs { ConversionSuccessful = status == 1 });

        protected void OnError(IntPtr converter, string message) => Error?.Invoke(this, new MessageEventArgs(message));

        protected void OnWarning(IntPtr converter, string message) => Warning?.Invoke(this, new MessageEventArgs(message));
    }
}

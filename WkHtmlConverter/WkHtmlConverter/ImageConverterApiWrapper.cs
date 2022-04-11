using System;
using System.Runtime.InteropServices;

namespace WkHtmlConverter
{
    internal sealed class ImageConverterApiWrapper : IDisposable
    {
        private bool _disposed;

        public bool IsLoaded { get; private set; }

        public bool ExtendedQt => WkHtmlToXBindings.wkhtmltoimage_extended_qt() == 1;

        public string LibraryVersion => Marshal.PtrToStringAnsi(WkHtmlToXBindings.wkhtmltoimage_version())!;


        public void Dispose()
        {
            Unload();
            GC.SuppressFinalize(this);
        }

        ~ImageConverterApiWrapper()
        {
            Unload();
        }

        public void Load()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(ImageConverterApiWrapper));
            }

            if (IsLoaded)
            {
                return;
            }

            if (WkHtmlToXBindings.wkhtmltoimage_init(0) == 1)
            {
                IsLoaded = true;
            }
        }
        
        private void Unload()
        {
            if (!_disposed)
            {
                WkHtmlToXBindings.wkhtmltoimage_deinit();

                _disposed = true;
                IsLoaded = false;
            }
        }

        public IntPtr CreateGlobalSettings() => 
            WkHtmlToXBindings.wkhtmltoimage_create_global_settings();

        public int SetGlobalSetting(IntPtr settings, string name, string? value) =>
            WkHtmlToXBindings.wkhtmltoimage_set_global_setting(settings, name, value);

        public unsafe string GetGlobalSetting(IntPtr settings, string name) =>
            BufferExtensions.InvokeBufferToUtf8Action(buffer =>
            {
                fixed (byte* tempBuffer = buffer)
                {
                    WkHtmlToXBindings.wkhtmltoimage_get_global_setting(settings, name, tempBuffer, buffer.Length);
                }
            });

        public void DestroyGlobalSetting(IntPtr settings) =>
            WkHtmlToXBindings.wkhtmltoimage_destroy_global_settings(settings);

        public IntPtr CreateConverter(IntPtr globalSettings, string? data = null) =>
            WkHtmlToXBindings.wkhtmltoimage_create_converter(globalSettings, data);

        public bool Convert(IntPtr converter) => WkHtmlToXBindings.wkhtmltoimage_convert(converter) == 1;

        public void DestroyConverter(IntPtr converter) => WkHtmlToXBindings.wkhtmltoimage_destroy_converter(converter);

        public byte[] GetConversionResult(IntPtr converter) => BufferExtensions.MarshalReturnBuffer(() =>
        {
            var dataLength = WkHtmlToXBindings.wkhtmltoimage_get_output(converter, out var dataPointer);
            return (dataPointer, dataLength);
        });

        public void SetPhaseChangedCallback(IntPtr converter, VoidCallback callback) =>
            WkHtmlToXBindings.wkhtmltoimage_set_phase_changed_callback(converter, callback);

        public void SetProgressChangedCallback(IntPtr converter, IntCallback callback) =>
            WkHtmlToXBindings.wkhtmltoimage_set_progress_changed_callback(converter, callback);

        public void SetFinishedCallback(IntPtr converter, IntCallback callback) =>
            WkHtmlToXBindings.wkhtmltoimage_set_finished_callback(converter, callback);

        public void SetWarningCallback(IntPtr converter, StringCallback callback) =>
            WkHtmlToXBindings.wkhtmltoimage_set_warning_callback(converter, callback);

        public void SetErrorCallback(IntPtr converter, StringCallback callback) =>
            WkHtmlToXBindings.wkhtmltoimage_set_error_callback(converter, callback);

        public int GetPhaseCount(IntPtr converter) => WkHtmlToXBindings.wkhtmltoimage_phase_count(converter);

        public int GetCurrentPhase(IntPtr converter) => WkHtmlToXBindings.wkhtmltoimage_current_phase(converter);

        public string GetCurrentPhaseDescription(IntPtr converter, int phase) => 
            Marshal.PtrToStringAnsi(WkHtmlToXBindings.wkhtmltoimage_phase_description(converter, phase)) ?? string.Empty;

        public string GetProgressString(IntPtr converter) =>
            Marshal.PtrToStringAnsi(WkHtmlToXBindings.wkhtmltoimage_progress_string(converter)) ?? string.Empty;

        public int GetHttpErrorCode(IntPtr converter) => WkHtmlToXBindings.wkhtmltoimage_http_error_code(converter);
    }
}

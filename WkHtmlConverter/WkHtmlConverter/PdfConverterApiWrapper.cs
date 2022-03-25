using System;
using System.Runtime.InteropServices;

namespace WkHtmlConverter
{
    internal sealed class PdfConverterApiWrapper : IDisposable
    {
        private bool _disposed;

        public bool IsLoaded { get; private set; }

        public bool ExtendedQt => WkHtmlToXBindings.wkhtmltopdf_extended_qt() == 1;

        public string LibraryVersion => Marshal.PtrToStringAnsi(WkHtmlToXBindings.wkhtmltopdf_version())!;


        public void Dispose()
        {
            Unload();
            GC.SuppressFinalize(this);
        }

        ~PdfConverterApiWrapper()
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

            if (WkHtmlToXBindings.wkhtmltopdf_init(0) == 1)
            {
                IsLoaded = true;
            }
        }

        private void Unload()
        {
            if (!_disposed)
            {
                WkHtmlToXBindings.wkhtmltopdf_deinit();

                _disposed = true;
                IsLoaded = false;
            }
        }

        public IntPtr CreateGlobalSettings() =>
            WkHtmlToXBindings.wkhtmltopdf_create_global_settings();

        public int SetGlobalSetting(IntPtr settings, string name, string value) =>
            WkHtmlToXBindings.wkhtmltopdf_set_global_setting(settings, name, value);

        public unsafe string GetGlobalSetting(IntPtr settings, string name) =>
            BufferExtensions.InvokeBufferToUtf8Action(buffer =>
            {
                fixed (byte* bufferPtr = buffer)
                {
                    WkHtmlToXBindings.wkhtmltopdf_get_global_setting(settings, name, bufferPtr, buffer.Length);
                }
            });

        public void DestroyGlobalSetting(IntPtr settings) =>
            WkHtmlToXBindings.wkhtmltopdf_destroy_global_settings(settings);

        public IntPtr CreateObjectSettings() => WkHtmlToXBindings.wkhtmltopdf_create_object_settings();

        public int SetObjectSettings(IntPtr settings, string name, string value) =>
            WkHtmlToXBindings.wkhtmltopdf_set_object_setting(settings, name, value);

        public unsafe string GetObjectSettings(IntPtr settings, string name) =>
            BufferExtensions.InvokeBufferToUtf8Action(buffer =>
            {
                fixed (byte* bufferPtr = buffer)
                {
                    WkHtmlToXBindings.wkhtmltopdf_get_object_setting(settings, name, bufferPtr, buffer.Length);
                }
            });

        public void AddObject(IntPtr converter, IntPtr objectSettings, string data) =>
            WkHtmlToXBindings.wkhtmltopdf_add_object(converter, objectSettings, data);

        public void DestroyObjectSettings(IntPtr settings) =>
            WkHtmlToXBindings.wkhtmltopdf_destroy_object_settings(settings);

        public IntPtr CreateConverter(IntPtr globalSettings) =>
            WkHtmlToXBindings.wkhtmltopdf_create_converter(globalSettings);

        public bool Convert(IntPtr converter) => WkHtmlToXBindings.wkhtmltopdf_convert(converter) == 1;

        public void DestroyConverter(IntPtr converter) => WkHtmlToXBindings.wkhtmltopdf_destroy_converter(converter);

        public byte[] GetConversionResult(IntPtr converter) => BufferExtensions.MarshalReturnBuffer(() =>
        {
            var dataLength = WkHtmlToXBindings.wkhtmltopdf_get_output(converter, out var dataPointer);
            return (dataPointer, dataLength);
        });

        public void SetPhaseChangedCallback(IntPtr converter, VoidCallback callback) =>
            WkHtmlToXBindings.wkhtmltopdf_set_phase_changed_callback(converter, callback);

        public void SetProgressChangedCallback(IntPtr converter, IntCallback callback) =>
            WkHtmlToXBindings.wkhtmltopdf_set_progress_changed_callback(converter, callback);

        public void SetFinishedCallback(IntPtr converter, IntCallback callback) =>
            WkHtmlToXBindings.wkhtmltopdf_set_finished_callback(converter, callback);

        public void SetDebugCallback(IntPtr converter, StringCallback callback) =>
            WkHtmlToXBindings.wkhtmltopdf_set_debug_callback(converter, callback);

        public void SetInfoCallback(IntPtr converter, StringCallback callback) =>
            WkHtmlToXBindings.wkhtmltopdf_set_info_callback(converter, callback);

        public void SetWarningCallback(IntPtr converter, StringCallback callback) =>
            WkHtmlToXBindings.wkhtmltopdf_set_warning_callback(converter, callback);

        public void SetErrorCallback(IntPtr converter, StringCallback callback) =>
            WkHtmlToXBindings.wkhtmltopdf_set_error_callback(converter, callback);

        public int GetPhaseCount(IntPtr converter) => WkHtmlToXBindings.wkhtmltopdf_phase_count(converter);

        public int GetCurrentPhase(IntPtr converter) => WkHtmlToXBindings.wkhtmltopdf_current_phase(converter);

        public string GetCurrentPhaseDescription(IntPtr converter, int phase) =>
            Marshal.PtrToStringAnsi(WkHtmlToXBindings.wkhtmltopdf_phase_description(converter, phase)) ?? string.Empty;

        public string GetProgressString(IntPtr converter) =>
            Marshal.PtrToStringAnsi(WkHtmlToXBindings.wkhtmltopdf_progress_string(converter)) ?? string.Empty;

        public int GetHttpErrorCode(IntPtr converter) => WkHtmlToXBindings.wkhtmltopdf_http_error_code(converter);
    }
}

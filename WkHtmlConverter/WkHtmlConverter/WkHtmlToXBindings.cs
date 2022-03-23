using System;
using System.Runtime.InteropServices;

namespace WkHtmlConverter
{
    public static unsafe class WkHtmlToXBindings
    {
        private const string LibWkhtmlToXDllName = "libwkhtmltox";

        private const CharSet CharSet = System.Runtime.InteropServices.CharSet.Unicode;

        private const short Lputf8Str = 48; // MarshallAs a pointer to a UTF-8 encoded string.

        // PDF conversion functions 
        // See: https://github.com/wkhtmltopdf/wkhtmltopdf/blob/master/src/lib/pdf.h
        #region HTML to PDF bindings
        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern int wkhtmltopdf_extended_qt();

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr wkhtmltopdf_version();

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern int wkhtmltopdf_init(int useGraphics);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern int wkhtmltopdf_deinit();

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr wkhtmltopdf_create_global_settings();

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet)]
        public static extern int wkhtmltopdf_set_global_setting(IntPtr settings,
            [MarshalAs(Lputf8Str)]
            string name,
            [MarshalAs(Lputf8Str)]
            string value);


        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet)]
        public static extern int wkhtmltopdf_get_global_setting(IntPtr settings,
            [MarshalAs(Lputf8Str)]
            string name,
            byte* value, int valueSize);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern int wkhtmltopdf_destroy_global_settings(IntPtr settings);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr wkhtmltopdf_create_object_settings();

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet)] 
        public static extern int wkhtmltopdf_set_object_setting(IntPtr settings,
            [MarshalAs(Lputf8Str)]
            string name,
            [MarshalAs(Lputf8Str)]
            string value);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet)]
        public static extern int wkhtmltopdf_get_object_setting(IntPtr settings,
            [MarshalAs(Lputf8Str)]
            string name,
            byte* value, int valueSize);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern int wkhtmltopdf_destroy_object_settings(IntPtr settings);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr wkhtmltopdf_create_converter(IntPtr globalSettings);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern void wkhtmltopdf_add_object(IntPtr converter,
            IntPtr objectSettings,
            byte[] data);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern void wkhtmltopdf_add_object(IntPtr converter,
            IntPtr objectSettings,
            [MarshalAs(Lputf8Str)] string data);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool wkhtmltopdf_convert(IntPtr converter);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern void wkhtmltopdf_destroy_converter(IntPtr converter);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern int wkhtmltopdf_get_output(IntPtr converter, out IntPtr data);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern int wkhtmltopdf_set_phase_changed_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] VoidCallback callback);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern int wkhtmltopdf_set_progress_changed_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] VoidCallback callback);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern int wkhtmltopdf_set_finished_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] IntCallback callback);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern int wkhtmltopdf_set_warning_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] StringCallback callback);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern int wkhtmltopdf_set_error_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] StringCallback callback);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern int wkhtmltopdf_phase_count(IntPtr converter);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern int wkhtmltopdf_current_phase(IntPtr converter);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr wkhtmltopdf_phase_description(IntPtr converter, int phase);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr wkhtmltopdf_progress_string(IntPtr converter);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern int wkhtmltopdf_http_error_code(IntPtr converter);

        #endregion

        // Image conversion functions 
        // See: https://github.com/wkhtmltopdf/wkhtmltopdf/blob/master/src/lib/image.h
        #region HTML to Image bindings
        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern int wkhtmltoimage_init(int useGraphics);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern int wkhtmltoimage_deinit();

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern int wkhtmltoimage_extended_qt();

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr wkhtmltoimage_version();

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr wkhtmltoimage_create_global_settings();

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet)]
        public static extern int wkhtmltoimage_set_global_setting(IntPtr settings,
            [MarshalAs(Lputf8Str)]
            string name,
            [MarshalAs(Lputf8Str)]
            string value);


        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet)]
        public static extern int wkhtmltoimage_get_global_setting(IntPtr settings,
            [MarshalAs(Lputf8Str)]
            string name,
            byte* value, int valueSize);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr wkhtmltoimage_create_converter(IntPtr globalSettings);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern void wkhtmltoimage_destroy_converter(IntPtr converter);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern void wkhtmltoimage_set_debug_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] StringCallback callback);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern void wkhtmltoimage_set_info_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] StringCallback callback);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern void wkhtmltoimage_set_warning_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] StringCallback callback);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern void wkhtmltoimage_set_error_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] StringCallback callback);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern void wkhtmltoimage_set_phase_changed_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] VoidCallback callback);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern void wkhtmltoimage_set_progress_changed_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] IntCallback callback);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern void wkhtmltoimage_set_finished_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] IntCallback callback);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern int wkhtmltoimage_convert(IntPtr converter);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern int wkhtmltoimage_current_phase(IntPtr converter);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern int wkhtmltoimage_phase_count(IntPtr converter);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr wkhtmltoimage_phase_description(IntPtr converter, int phase);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr wkhtmltoimage_progress_string(IntPtr converter);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern int wkhtmltoimage_http_error_code(IntPtr converter);

        [DllImport(LibWkhtmlToXDllName, CharSet = CharSet, CallingConvention = CallingConvention.Cdecl)]
        public static extern int wkhtmltoimage_get_output(IntPtr converter, out IntPtr data);

        #endregion
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void StringCallback(IntPtr converter, [MarshalAs(UnmanagedType.LPStr)] string str);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void IntCallback(IntPtr converter, int integer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void VoidCallback(IntPtr converter);
}
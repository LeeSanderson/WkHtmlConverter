using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace WkHtmlConverter
{
    /// <summary>
    /// Loader to ensure that the libwkhtmltox library is available - copying the embedded file to the local file system if necessary.
    /// Implemented as a thread-safe, lazy loaded singleton as described here: https://jonskeet.uk/csharp/singleton.html
    /// </summary>
    internal sealed class WkLibraryLoader
    {
        private readonly Exception? _initializationException;


        private WkLibraryLoader()
        {
            // Code here will only be called once when Instance is accessed
            try
            {
                EnsureWkLibraryExists();
            }
            catch (Exception e)
            {
                _initializationException = e;
            }
        }

        public static WkLibraryLoader Instance => Nested.LazyInstance;

        public void Initialize()
        {
            if (_initializationException != null)
                throw new Exception($"An error occurred initializing the {nameof(WkLibraryLoader)}", _initializationException);
        }

        private void EnsureWkLibraryExists()
        {
            var libWkhtmlToXFileName = GetPlatformSpecificLibraryName();
            if (File.Exists(libWkhtmlToXFileName))
            {
                return;
            }

            var assembly = typeof(WkLibraryLoader).Assembly;
            var resourceName = 
                assembly
                    .GetManifestResourceNames()
                    .FirstOrDefault(x => x.EndsWith(libWkhtmlToXFileName, true, CultureInfo.InvariantCulture));
            if (resourceName == null)
                throw new Exception($"Unable to find embedded resource {libWkhtmlToXFileName}");

            using var resourceStream = assembly.GetManifestResourceStream(resourceName)!;
            using var fileStream = new FileStream(libWkhtmlToXFileName, FileMode.Create);
            resourceStream.CopyTo(fileStream);
        }

        private string GetPlatformSpecificLibraryName()
        {
            return GetPlatform() switch
            {
                Platform.Windows => "libwkhtmltox.dll",
                Platform.MacOs => "libwkhtmltox.dylib",
                Platform.Linux => "libwkhtmltox.so",
                _ => throw new Exception("Unsupported platform: unable to determine whether running on Windows, MacOs, or Linux")
            };
        }

        private Platform GetPlatform()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return Platform.Windows;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return Platform.MacOs;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return Platform.Linux;

            throw new Exception("Unsupported platform: unable to determine whether running on Windows, MacOs, or Linux");
        }

        private enum Platform
        {
            Windows,
            MacOs,
            Linux
        }

        // ReSharper disable once ClassNeverInstantiated.Local
        private class Nested
        {
            static Nested()
            {
                // Explicit static constructor to tell C# compiler
                // not to mark type as beforefieldinit
            }

            internal static readonly WkLibraryLoader LazyInstance = new();
        }
    }
}
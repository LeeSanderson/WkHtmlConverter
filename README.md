# WkHtmlConverter
A cross platform .net library for converting HTML to PDF and HTML to images using 
the [wkhtmltox](https://github.com/wkhtmltopdf/wkhtmltopdf) library.

[wkhtmltox](https://github.com/wkhtmltopdf/wkhtmltopdf) uses the QT Webkit rendering engine. It runs entirely headless and does not require a display or display service.

Details of the command line tools wkhtmltopdf and wkhtmltoimage can be found on the [WK&lt;html&gt;TOpdf website](https://wkhtmltopdf.org/).

The .net code works by using [P/Invoke](https://docs.microsoft.com/en-us/dotnet/standard/native-interop/pinvoke) to call the unmanaged code in the [libwkhtmltox](https://wkhtmltopdf.org/libwkhtmltox/) library. The libwkhtmltox is embedded in the .net assembly to make deploying applications that use the assembly easier. The library is extracted at runtime if it cannot be found on the path by the managed code. 

## Current version

The WkHtmlConverter .net library is currently compiled and tested against [current stable version](https://wkhtmltopdf.org/downloads.html) of libwkhtmltox (version 0.12.6) which was release 11th June 2020.

To upgrade the version of libwkhtmltox complete the following steps:
 - Go to the [download page](https://wkhtmltopdf.org/downloads.html).
 - Download the 64-bit Windows 7z Archive.
 - Extract the wkhtmltox.dll from the archive using [7zip](https://www.7-zip.org/) (from the "\wkhtmltox\bin\" path).
 - Rename the DLL to libwkhtmltox.dll and copy to the root folder of the  [WkHtmlConverter project](https://github.com/LeeSanderson/WkHtmlConverter/tree/main/WkHtmlConverter/WkHtmlConverter).
 - Back on the download page, download the macOS 64-bit pkg installer file.
 - Open the pkg installer file with 7zip and extract the libwkhtmltox[version_number].dll file from the "\Payload~\.\usr\local\share\wkhtmltox-installer\wkhtmltox.tar.gz\wkhtmltox.tar\.\lib\" path.
- Rename the dylib file to libwkhtmltox.dylib and copy to the root folder of the  [WkHtmlConverter project](https://github.com/LeeSanderson/WkHtmlConverter/tree/main/WkHtmlConverter/WkHtmlConverter).
 - Back on the download page, download the latest Ububtu amd64 deb installer file.
 - Open the deb installer file with 7zip and extract the libwkhtmltox.so.[version_number] file from the "\data.tar.xz\data.tar\.\usr\local\lib\" path.
- Rename the shared object file to libwkhtmltox.so and copy to the root folder of the  [WkHtmlConverter project](https://github.com/LeeSanderson/WkHtmlConverter/tree/main/WkHtmlConverter/WkHtmlConverter).

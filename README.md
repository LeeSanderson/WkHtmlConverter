<img align="left" style="padding-right:20px" width="128" height="90" src="WkHtmlConverter/WkHtmlConverter/NuGet/icon.png" />

# WkHtmlConverter

[![Build Status](https://dev.azure.com/sixsideddice/SixSidedDice/_apis/build/status/WkHtmlConverterProd?branchName=main)](https://dev.azure.com/sixsideddice/SixSidedDice/_build/latest?definitionId=3&branchName=main)
![Nuget](https://img.shields.io/nuget/dt/WkHtmlConverter)
![Nuget](https://img.shields.io/nuget/v/WkHtmlConverter)

A cross platform .net library for converting HTML to PDF and HTML to images using 
the [wkhtmltox](https://github.com/wkhtmltopdf/wkhtmltopdf) library.

[wkhtmltox](https://github.com/wkhtmltopdf/wkhtmltopdf) uses the QT Webkit rendering engine. It runs entirely headless and does not require a display or display service.

Details of the command line tools wkhtmltopdf and wkhtmltoimage can be found on the [WK&lt;html&gt;TOpdf website](https://wkhtmltopdf.org/).

The .net code works by using [P/Invoke](https://docs.microsoft.com/en-us/dotnet/standard/native-interop/pinvoke) to call the unmanaged code in the [libwkhtmltox](https://wkhtmltopdf.org/libwkhtmltox/) library. 
The libwkhtmltox is embedded in the .net assembly to make deploying applications that use the assembly easier. 
The library is extracted at runtime if it cannot be found on the path by the managed code. 

## Current version



The WkHtmlConverter .net library is currently compiled and tested against the [current stable version](https://wkhtmltopdf.org/downloads.html) of 
libwkhtmltox (version 0.12.6) which was release 11th June 2020. The underlying WebKit version included in this build is 534.34.
This is roughly equivalent to [Safari version 5.0.6](https://en.wikipedia.org/wiki/Safari_version_history#Safari_5).
Because this is an old version of WebKit, many modern HTML, JavaScript and CSS features [may not be supported](https://caniuse.com/?compare=safari+5&compareCats=all).

## Upgrading the current version
In the unlikely event that a new version of libwkhtmltox becomes available then the project can be upgraded.

To upgrade complete the following steps:
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

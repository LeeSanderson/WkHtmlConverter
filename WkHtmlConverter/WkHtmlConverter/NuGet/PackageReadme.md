# WkHtmlConverter

[WkHtmlConverter](https://github.com/LeeSanderson/WkHtmlConverter) is a cross platform .NET library for converting HTML to PDF and HTML to images using 
the [wkhtmltox](https://github.com/wkhtmltopdf/wkhtmltopdf) library.

The WkHtmlConverter NuGet package is distributed under a [MIT Licence](https://github.com/LeeSanderson/WkHtmlConverter/blob/main/LICENSE) allowing the package to be freely used in commercial applications.

## Example 1 - converting HTML to an image

```csharp
var converter = new HtmlToImageConverter();
var settings = new ImageConversionSettings { Format = ImageOutputFormat.Png };
var html = "<h1>Hello World</h1>";
var imageBytes = await converter.ConvertAsync(settings, html);
await File.WriteAllBytesAsync("HelloWorld.png", imageBytes);
```

## Example 2 - converting HTML to a PDF

```csharp
var converter = new HtmlToPdfConverter();
var settings = new PdfConversionSettings
{
    GlobalSettings = new PdfConversionGlobalSettings(),
    Sections = new List<PdfConversionObjectSettings>
    {
        new()
    }
};

var html = "<h1>Hello World</h1>";
var pdfBytes = await converter.ConvertAsync(settings, html);
await File.WriteAllBytesAsync("HelloWorld.pdf", result);
```


## Version History

| Version | Major Changes |  
| --- | --- | 
| 0.1.1 | Tidy up NugGet package, changed to MIT licence |  
| 0.1.0 | Initial version |  

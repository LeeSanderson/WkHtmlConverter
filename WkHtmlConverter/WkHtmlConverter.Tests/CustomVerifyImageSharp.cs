﻿using System.Collections.Generic;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Tiff;
using VerifyTests;

namespace WkHtmlConverter.Tests
{
    internal static class CustomVerifyImageSharp
    {
        public static void Initialize()
        {
            VerifierSettings.RegisterFileConverter("bmp", ConvertBmp);
            VerifierSettings.RegisterFileConverter("gif", ConvertGif);
            VerifierSettings.RegisterFileConverter("jpg", ConvertJpg);
            VerifierSettings.RegisterFileConverter("png", ConvertPng);
            VerifierSettings.RegisterFileConverter("tif", ConvertTiff);

            var encoder = new PngEncoder();
            VerifierSettings.RegisterFileConverter<Image>((image, context) => ConvertImage(image, context, "png", encoder));
        }

        static ConversionResult ConvertImage(Image image, IReadOnlyDictionary<string, object> context, string extension, IImageEncoder encoder)
        {
            if (context.TryGetValue("ImageSharpEncoder", out var encoderValue))
            {
                extension = (string)context["ImageSharpExtension"];
                encoder = (IImageEncoder)encoderValue;
            }

            return Convert(image, extension, encoder);
        }

        static void EncodeAs<TEncoder>(this VerifySettings settings, string extension, IImageEncoder? encoder)
            where TEncoder : IImageEncoder, new()
        {
            settings.Context["ImageSharpEncoder"] = encoder ?? new TEncoder();
            ;
            settings.Context["ImageSharpExtension"] = extension;
        }

        public static void EncodeAsPng(this VerifySettings settings, PngEncoder? encoder = null)
        {
            settings.EncodeAs<PngEncoder>("png", encoder);
        }

        public static SettingsTask EncodeAsPng(this SettingsTask settings, PngEncoder? encoder = null)
        {
            settings.CurrentSettings.EncodeAsPng(encoder);
            return settings;
        }

        public static SettingsTask EncodeAsGif(this SettingsTask settings, GifEncoder? encoder = null)
        {
            settings.CurrentSettings.EncodeAsGif(encoder);
            return settings;
        }

        public static void EncodeAsGif(this VerifySettings settings, GifEncoder? encoder = null)
        {
            settings.EncodeAs<GifEncoder>("gif", encoder);
        }

        public static SettingsTask EncodeAsTiff(this SettingsTask settings, TiffEncoder? encoder = null)
        {
            settings.CurrentSettings.EncodeAsTiff(encoder);
            return settings;
        }

        public static void EncodeAsTiff(this VerifySettings settings, TiffEncoder? encoder = null)
        {
            settings.EncodeAs<TiffEncoder>("tif", encoder);
        }

        public static SettingsTask EncodeAsBmp(this SettingsTask settings, BmpEncoder? encoder = null)
        {
            settings.CurrentSettings.EncodeAsBmp(encoder);
            return settings;
        }

        public static void EncodeAsBmp(this VerifySettings settings, BmpEncoder? encoder = null)
        {
            settings.EncodeAs<BmpEncoder>("bmp", encoder);
        }

        public static SettingsTask EncodeAsJpeg(this SettingsTask settings, JpegEncoder? encoder = null)
        {
            settings.CurrentSettings.EncodeAsJpeg(encoder);
            return settings;
        }

        public static void EncodeAsJpeg(this VerifySettings settings, JpegEncoder? encoder = null)
        {
            settings.EncodeAs<JpegEncoder>("jpg", encoder);
        }

        static ConversionResult Convert(Image image, string extension, IImageEncoder encoder)
        {
            var stream = new MemoryStream();
            var info = image.GetInfo();
            image.Save(stream, encoder);
            stream.Position = 0;
            return new(info, extension, stream);
        }

        public static object GetInfo(this Image image)
        {
            var metadata = image.Metadata;
            return new
            {
                image.Width,
                image.Height,
                // HorizontalResolution and VerticalResolution can be different when running on different devices
                // metadata.HorizontalResolution,
                // metadata.VerticalResolution,
                metadata.ResolutionUnits,
            };
        }

        static ConversionResult ConvertBmp(Stream stream, IReadOnlyDictionary<string, object> context)
        {
            return Convert<BmpDecoder, BmpEncoder>(stream, "bmp", context);
        }

        static ConversionResult ConvertGif(Stream stream, IReadOnlyDictionary<string, object> context)
        {
            return Convert<GifDecoder, GifEncoder>(stream, "gif", context);
        }

        static ConversionResult ConvertJpg(Stream stream, IReadOnlyDictionary<string, object> context)
        {
            return Convert<JpegDecoder, JpegEncoder>(stream, "jpg", context);
        }

        static ConversionResult ConvertPng(Stream stream, IReadOnlyDictionary<string, object> context)
        {
            return Convert<PngDecoder, PngEncoder>(stream, "png", context);
        }

        static ConversionResult ConvertTiff(Stream stream, IReadOnlyDictionary<string, object> context)
        {
            return Convert<TiffDecoder, TiffEncoder>(stream, "tif", context);
        }

        static ConversionResult Convert<TDecoder, TEncoder>(Stream stream, string extension, IReadOnlyDictionary<string, object> context)
            where TDecoder : IImageDecoder, new()
            where TEncoder : IImageEncoder, new()
        {
            var image = Image.Load(stream, new TDecoder());
            stream.Position = 0;
            return ConvertImage(image, context, extension, new TEncoder());
        }
    }
}

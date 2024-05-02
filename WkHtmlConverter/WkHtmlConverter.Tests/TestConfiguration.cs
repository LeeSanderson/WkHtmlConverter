namespace WkHtmlConverter.Tests;

public static class TestConfiguration
{
    public const string SkipImageConverterTestsForPipelineBuilds = 
        "Image Converter Tests Should be skipped in pipeline builds because they can generate different image properties (resolution/height etc.)";
}
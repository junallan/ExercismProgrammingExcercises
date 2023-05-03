using System;
using BenchmarkDotNet.Attributes;


public class MarkdownBenchmark
{
    private const string MarkdownText = "# Header 1\n## Header 2\n### Header 3\n#### Header 4\n##### Header 5\n###### Header 6\n\n* Item 1\n* Item 2\n* Item 3\n\nThis is a **bold** and _italic_ text.\n\n";

    [Benchmark]
    public void Test()
    {
        Markdown.Parse(MarkdownText);
    }
}



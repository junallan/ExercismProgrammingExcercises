﻿// See https://aka.ms/new-console-template for more information
using System.Text;
using BenchmarkDotNet.Attributes;
using Xunit;

[MemoryDiagnoser]
public class Demo
{
    private const string IliadFileName = "iliad.txt";
    private const string IliadContents =
        "Achilles sing, O Goddess! Peleus' son;\n" +
        "His wrath pernicious, who ten thousand woes\n" +
        "Caused to Achaia's host, sent many a soul\n" +
        "Illustrious into Ades premature,\n" +
        "And Heroes gave (so stood the will of Jove)\n" +
        "To dogs and to all ravening fowls a prey,\n" +
        "When fierce dispute had separated once\n" +
        "The noble Chief Achilles from the son\n" +
        "Of Atreus, Agamemnon, King of men.\n";

    private const string MidsummerNightFileName = "midsummer-night.txt";
    private const string MidsummerNightContents =
        "I do entreat your grace to pardon me.\n" +
        "I know not by what power I am made bold,\n" +
        "Nor how it may concern my modesty,\n" +
        "In such a presence here to plead my thoughts;\n" +
        "But I beseech your grace that I may know\n" +
        "The worst that may befall me in this case,\n" +
        "If I refuse to wed Demetrius.\n";

    private const string ParadiseLostFileName = "paradise-lost.txt";
    private const string ParadiseLostContents =
        "Of Mans First Disobedience, and the Fruit\n" +
        "Of that Forbidden Tree, whose mortal tast\n" +
        "Brought Death into the World, and all our woe,\n" +
        "With loss of Eden, till one greater Man\n" +
        "Restore us, and regain the blissful Seat,\n" +
        "Sing Heav'nly Muse, that on the secret top\n" +
        "Of Oreb, or of Sinai, didst inspire\n" +
        "That Shepherd, who first taught the chosen Seed\n";

    public static void CreateFiles()
    {
        Directory.SetCurrentDirectory(Path.GetTempPath());
        File.WriteAllText(IliadFileName, IliadContents);
        File.WriteAllText(MidsummerNightFileName, MidsummerNightContents);
        File.WriteAllText(ParadiseLostFileName, ParadiseLostContents);
    }

    public static void DeleteFiles()
    {
        Directory.SetCurrentDirectory(Path.GetTempPath());
        File.Delete(IliadFileName);
        File.Delete(MidsummerNightFileName);
        File.Delete(ParadiseLostFileName);
    }

    [Benchmark]
    public string GrepFirstIteration()
    {
        CreateFiles();
        var pattern = "Illustrious into Ades premature,";
        var flags = "-x -v";
        var files = new[] { IliadFileName, "midsummer-night.txt", "paradise-lost.txt" };
            
        var result = GrepOriginal.Match(pattern, flags, files);
        DeleteFiles();
        return result;
    }

    [Benchmark]
    public string GrepRevised()
    {
        CreateFiles();
        var pattern = "Illustrious into Ades premature,";
        var flags = "-x -v";
        var files = new[] { IliadFileName, "midsummer-night.txt", "paradise-lost.txt" };

        var result = Grep.Match(pattern, flags, files);
        DeleteFiles();
        return result;
    }



    //[Benchmark]
    //public string MarkdownParse()
    //{
    //    var markdown =
    //       "# Start a list\n" +
    //       "* Item 1\n" +
    //       "* Item 2\n" +
    //       "End a list";

    //    return Markdown.Parse(markdown);
    //}

    //[Benchmark]
    //public string MarkdownParseOriginal()
    //{
    //    var markdown =
    //       "# Start a list\n" +
    //       "* Item 1\n" +
    //       "* Item 2\n" +
    //       "End a list";

    //    return Markdown.Parse(markdown);
    //}


    //[Benchmark]
    //public string GetFullStringNormally()
    //{
    //    //return Markdown.Parse(MarkdownText);
    //    var output = "";

    //    for (int i = 0; i < 100; i++)
    //    {
    //        output += i;
    //    }

    //    return output;
    //}

    //[Benchmark]
    //public string GetFullStringWithStringBuilder()
    //{
    //    var output = new StringBuilder();

    //    for(int i = 0; i<100; i++)
    //    {
    //        output.Append(i);
    //    }

    //    return output.ToString();
    //}
}

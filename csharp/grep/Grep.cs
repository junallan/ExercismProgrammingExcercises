using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


public static class Grep
{
    [Flags]
    public enum Options
    {
        LineNumbers = 1,//-n
        FileNames = 2,//-l
        CaseInsensitiveMatch = 4, //-i
        InvertProgramMatch = 8,//-v
        EntireLineMatch = 16//-x
    }

    public static class OptionTranslation
    {
        private static readonly Dictionary<string, Options> FlagsToOptions= new Dictionary<string, Options>
        {
            { "-n", Options.LineNumbers },
            { "-l", Options.FileNames },
            { "-i", Options.CaseInsensitiveMatch },
            { "-v", Options.InvertProgramMatch },
            { "-x", Options.EntireLineMatch }
        };

        public static List<Options> GetOptions(string flags)
        {
            var optionsSelected = new List<Options>();

            if (string.IsNullOrEmpty(flags)) return optionsSelected;

            var matchOptions = flags.Split().AsEnumerable();

            foreach(var option in matchOptions)
            {
                optionsSelected.Add(FlagsToOptions[option]);
            }

            return optionsSelected;
        }
    }


    public static string Match(string pattern, string flags, string[] files)
    {
        var result = new StringBuilder();
        var optionsSelected = OptionTranslation.GetOptions(flags);

        foreach (var fileName in files)
        {
            var matchedLine = FileMatch(pattern, fileName, files, optionsSelected);

            if (!string.IsNullOrEmpty(matchedLine))
            {
                if (result.Length > 0) result.Append("\n");
                   
                result.Append(matchedLine);
            }
        }

        return result.ToString();
    }


    private static string FileMatch(
        string pattern, string fileName, string[] files, List<Options> optionsSelected)
    {
        var result = new StringBuilder();

        var fileContents = File.ReadAllText(fileName)
                        .Split("\n")
                        .Where(x => x != string.Empty)
                        .AsEnumerable();

        for (int lineNumber = 1; lineNumber <= fileContents.Count(); lineNumber++)
        {
            var isMatch = false;

            var lineContent = fileContents.ElementAt(lineNumber - 1);

            if (optionsSelected.Contains(Options.CaseInsensitiveMatch)
                && lineContent.ToLower().Contains(pattern.ToLower()))
                isMatch = true;
            else if (optionsSelected.Contains(Options.EntireLineMatch) && lineContent == pattern)
                isMatch = true;
            else if (!(optionsSelected.Contains(Options.CaseInsensitiveMatch)
                || optionsSelected.Contains(Options.EntireLineMatch)))
                isMatch = lineContent.Contains(pattern);

            if (optionsSelected.Contains(Options.InvertProgramMatch))
                isMatch = !isMatch;

            if (!isMatch) continue;

            if (result.Length > 0) result.Append("\n");

            if (optionsSelected.Contains(Options.FileNames))
            {
                result.Append(fileName);

                if (files.Count() > 1)
                    break;

                continue;
            }

            if (files.Count() > 1) result.Append($"{fileName}:");

            if (optionsSelected.Contains(Options.LineNumbers))
                result.Append($"{lineNumber}:{lineContent}");
            else
                result.Append(lineContent);
        }

        return result.ToString();
    }
}
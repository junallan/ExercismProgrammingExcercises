using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


public static class Grep
{
    private static class OptionTranslation
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
        private static readonly Dictionary<string, Options> FlagsToOptions= new Dictionary<string, Options>
        {
            { "-n", Options.LineNumbers },
            { "-l", Options.FileNames },
            { "-i", Options.CaseInsensitiveMatch },
            { "-v", Options.InvertProgramMatch },
            { "-x", Options.EntireLineMatch }
        };

        public static int GetOptions(string flags)
        {
            var optionsSelected = 0;

            if (string.IsNullOrEmpty(flags)) return optionsSelected;

            var matchOptions = flags.Split().AsEnumerable();

            foreach (var option in matchOptions)
            {
                optionsSelected |= (int)FlagsToOptions[option];
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
        string pattern, string fileName, string[] files, int optionsSelected)
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

            if ((optionsSelected & (int)OptionTranslation.Options.CaseInsensitiveMatch) > 0
                && lineContent.ToLower().Contains(pattern.ToLower()))
                isMatch = true;
            else if ((optionsSelected & (int)OptionTranslation.Options.EntireLineMatch) > 0
                && lineContent == pattern)
                isMatch = true;
            else if (!((optionsSelected &
                ((int)OptionTranslation.Options.CaseInsensitiveMatch | (int)OptionTranslation.Options.EntireLineMatch)) > 0))
                isMatch = lineContent.Contains(pattern);

            if ((optionsSelected & (int)OptionTranslation.Options.InvertProgramMatch) > 0)
                isMatch = !isMatch;

            if (!isMatch) continue;

            if (result.Length > 0) result.Append("\n");

            if ((optionsSelected & (int)OptionTranslation.Options.FileNames) > 0)
            {
                result.Append(fileName);

                if (files.Count() > 1)
                    break;

                continue;
            }

            if (files.Count() > 1) result.Append($"{fileName}:");

            if ((optionsSelected & (int)OptionTranslation.Options.LineNumbers) > 0)
                result.Append($"{lineNumber}:{lineContent}");
            else
                result.Append(lineContent);
        }

        return result.ToString();
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


public static class Grep
{
    private class Options
    {
        [Flags]
        public enum Flags
        {
            N = 1, // line numbers
            L = 2, // filenames
            I = 4, // case insensitive match
            V = 8, // invert match
            X = 16 // entire line match
        }

        private readonly int options;

        public Options(string flags)
        {
            options = flags.ToArray().Where(o => o != '-' && o != ' ')
                .Select(o => Enum.Parse<Flags>(o.ToString().Substring(0, 1).AsSpan(), true))
                .Aggregate(0, (acc, x) => acc |= (int)x);
        }

        public bool LineNumbers => (options & (int)Flags.N) > 0;
        public bool FileNames => (options & (int)Flags.L) > 0;
        public bool CaseInSensitiveMatch => (options & (int)Flags.I) > 0;
        public bool EntireLineMatch => (options & (int)Flags.X) > 0;
        public bool InvertMatch => (options & (int)Flags.V) > 0;
    }

 
    private class MatchEvaluation
    {
        private readonly Options options;

        public MatchEvaluation(Options options)
        {
            this.options = options;
        }

        public bool IsMatched(string pattern, string content)
        {
            var matched = false;

            if (options.CaseInSensitiveMatch && content.ToLower().Contains(pattern.ToLower()))
                matched = true;
            else if (options.EntireLineMatch && content == pattern)
                matched = true;
            else if (!options.CaseInSensitiveMatch && !options.EntireLineMatch)
                matched = content.Contains(pattern);

            if (options.InvertMatch) matched = !matched;

            return matched;
        }
    }


    public static string Match(string pattern, string flags, string[] files)
    {
        var result = new StringBuilder();
        var optionsSelected = new Options(flags);

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
        string pattern, string fileName, string[] files, Options optionsSelected)
    {
        var result = new StringBuilder();

        var fileContents = File.ReadAllText(fileName)
                        .Split("\n")
                        .Where(x => x != string.Empty)
                        .AsEnumerable();

        var matchEvaluation = new MatchEvaluation(optionsSelected);

        for (int lineNumber = 1; lineNumber <= fileContents.Count(); lineNumber++)
        {
            var lineContent = fileContents.ElementAt(lineNumber - 1);

            if (!matchEvaluation.IsMatched(pattern, lineContent)) continue;

            if (result.Length > 0) result.Append("\n");

            if (optionsSelected.FileNames)
            {
                result.Append(fileName);

                if (files.Count() > 1)
                    break;

                continue;
            }

            if (files.Count() > 1) result.Append($"{fileName}:");

            if (optionsSelected.LineNumbers)
                result.Append($"{lineNumber}:{lineContent}");
            else
                result.Append(lineContent);
        }

        return result.ToString();
    }
}
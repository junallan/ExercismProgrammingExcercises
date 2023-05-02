using System;
using System.Linq;
using System.Text;


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

        private readonly Flags options;

        public Options(string flags)
        {
            options = (Flags)flags.ToArray().Where(o => o != '-' && o != ' ')
                .Select(o => Enum.Parse<Flags>(o.ToString(), true))
                .Aggregate(0, (acc, x) => acc |= (int)x);
        }

        public bool LineNumbers => (options & Flags.N) > 0;
        public bool FileNames => (options & Flags.L) > 0;
        public bool CaseInSensitiveMatch => (options & Flags.I) > 0;
        public bool EntireLineMatch => (options & Flags.X) > 0;
        public bool InvertMatch => (options & Flags.V) > 0;
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

        var fileContents = System.IO.File.ReadAllText(fileName)
                        .Split("\n")
                        .Where(x => x != string.Empty)
                        .AsEnumerable();

        var matchEvaluation = new MatchEvaluation(optionsSelected);

        for (int lineNumber = 1; lineNumber <= fileContents.Count(); lineNumber++)
        {
            var lineContent = fileContents.ElementAt(lineNumber - 1);

            if (!matchEvaluation.IsMatched(pattern, lineContent)) continue;

            var content = AddMatchingContent(optionsSelected, fileName, files.Count() > 1, lineContent, lineNumber);

            if (result.Length > 0) result.Append("\n");

            if (!content.LookAtNextLine) return content.MatchedResult;

            result.Append(content.MatchedResult);
        }

        return result.ToString();
    }


    private static (bool LookAtNextLine, string MatchedResult) AddMatchingContent(
        Options optionsSelected, string fileName, bool multipleFiles, string lineContent, int lineNumber)
    {
        if (optionsSelected.FileNames)
        {
            if (multipleFiles) return (false, fileName);

            return (true, fileName);
        }
  
        var fileNameContent = multipleFiles ? $"{fileName}:" : string.Empty;

        if (optionsSelected.LineNumbers)
            return (true, $"{fileNameContent}{lineNumber}:{lineContent}");

        return (true, $"{fileNameContent}{lineContent}");
    }
}
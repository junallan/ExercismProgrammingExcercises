using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


public static class Grep
{
    public static string Match(string pattern, string flags, string[] files)
    {
        var result = new StringBuilder();

        var matchOptions = flags.Split().AsEnumerable();

        var match = MatchOption(matchOptions);

        foreach (var fileName in files)
        {
            var matchedLine = FileMatch(pattern, fileName, files, matchOptions, match);

            if (!string.IsNullOrEmpty(matchedLine))
            {
                if (result.Length > 0) result.Append("\n");
                   
                result.Append(matchedLine);
            }
        }

        return result.ToString();
    }


    private static string FileMatch(
        string pattern, string fileName, string[] files, IEnumerable<string> matchOptions,
        (bool IsCaseInsensitiveMatch, bool IsWholeLineMatch, bool IsInvertedMatch) match)
    {
        var result = new StringBuilder();

        var fileContents = File.ReadAllText(fileName)
                        .Split("\n")
                        .Where(x => x != string.Empty)
                        .ToArray();

        for (int lineNumber = 1; lineNumber <= fileContents.Length; lineNumber++)
        {
            var isMatch = false;

            var lineContent = fileContents[lineNumber - 1];

            if (match.IsCaseInsensitiveMatch && lineContent.ToLower().Contains(pattern.ToLower()))
                isMatch = true;
            else if (match.IsWholeLineMatch && lineContent == pattern)
                isMatch = true;
            else if (!(match.IsCaseInsensitiveMatch || match.IsWholeLineMatch))
                isMatch = lineContent.Contains(pattern);

            if (match.IsInvertedMatch)
                isMatch = !isMatch;

            if (!isMatch) continue;

            if (result.Length > 0) result.Append("\n");

            if (matchOptions.Contains("-l"))
            {
                result.Append(fileName);

                if (files.Count() > 1)
                    break;

                continue;
            }

            if (files.Count() > 1) result.Append($"{fileName}:");

            if (matchOptions.Contains("-n"))
                result.Append($"{lineNumber}:{lineContent}");
            else
                result.Append(lineContent);
        }

        return result.ToString();
    }


    private static (bool IsCaseInsensitiveMatch, bool IsWholeLineMatch, bool IsInvertedMatch)
        MatchOption(IEnumerable<string> matchOptions)
    {
        var isCaseInsensitiveMatch = false;
        var isWholeLineMatch = false;
        var isInvertedMatch = false;

        foreach (var option in matchOptions)
        {
            if (option.Contains("-i"))
                isCaseInsensitiveMatch = true;
            else if (option.Contains("-x"))
                isWholeLineMatch = true;
            else if (option.Contains("-v"))
                isInvertedMatch = true;
        }
        return (isCaseInsensitiveMatch, isWholeLineMatch, isInvertedMatch);
    }

}
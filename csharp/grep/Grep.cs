using System;
using System.IO;
using System.Linq;
using System.Text;

public static class Grep
{
    public static string Match(string pattern, string flags, string[] files)
    {
        var result = new StringBuilder();

        var matchOptions = flags.Split().AsEnumerable();

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

        foreach (var fileName in files)
        {
            var fileContents = File.ReadAllText(fileName)
                .Split("\n")
                .Where(x => x != string.Empty)
                .ToArray();

            for (int lineNumber = 1; lineNumber <= fileContents.Length; lineNumber++)
            {
                var isMatch = false;

                var lineContent = fileContents[lineNumber - 1];

                if (isCaseInsensitiveMatch && lineContent.ToLower().Contains(pattern.ToLower()))
                    isMatch = true;
                else if (isWholeLineMatch && lineContent == pattern)
                    isMatch = true;
                else if(!(isCaseInsensitiveMatch || isWholeLineMatch))
                    isMatch = lineContent.Contains(pattern);

                if (isInvertedMatch)
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
                
        }

        return result.ToString();
    }
}
using System;
using System.IO;
using System.Text;

public static class Grep
{
    public static string Match(string pattern, string flags, string[] files)
    {
        var result = new StringBuilder();

        foreach(var fileName in files)
        {
            var fileContents = File.ReadAllText(fileName).Split("\n");

            for (int lineNumber = 1; lineNumber <= fileContents.Length; lineNumber++)
            {
                var lineContent = fileContents[lineNumber - 1];
                var content = flags switch
                {
                    "-n" => $"{lineNumber}:{lineContent}",
                    _ => lineContent
                };

                if (fileContents[lineNumber - 1].Contains(pattern)) result.Append(content);
            }
                
        }

        return result.ToString();
    }
}
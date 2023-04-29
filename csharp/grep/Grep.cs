using System;
using System.IO;
using System.Linq;
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

               var matchOptions = flags.Split().AsEnumerable();

               var isMatch =
                     matchOptions.Contains("-i")
                     ? lineContent.ToLower().Contains(pattern.ToLower())
                     : matchOptions.Contains("-x")
                     ? lineContent == pattern
                     : lineContent.Contains(pattern);

               if (!isMatch) continue;
       
               if (matchOptions.Contains("-l"))
                    result.Append(fileName);
               else
                    if (matchOptions.Contains("-n"))
                        result.Append($"{lineNumber}:{lineContent}");
                    else
                        result.Append(lineContent);
            }
                
        }

        return result.ToString();
    }
}
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
          
               switch (flags)
                {
                    case "-n":
                        if (lineContent.Contains(pattern))
                            result.Append($"{lineNumber}:{lineContent}");
                        break;
                    case "-i":
                        if (lineContent.ToLower().Contains(pattern.ToLower()))
                            result.Append(lineContent);
                        break;
                    case "-l":
                        if (lineContent.Contains(pattern))
                            result.Append(fileName);
                        break;
                    default:
                        if (lineContent.Contains(pattern))
                            result.Append(lineContent);
                        break;
                }
            }
                
        }

        return result.ToString();
    }
}
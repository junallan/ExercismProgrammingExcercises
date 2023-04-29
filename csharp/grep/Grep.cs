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

            foreach(var line in fileContents)
                if (line.Contains(pattern)) result.Append(line);
        }

        return result.ToString();
    }
}
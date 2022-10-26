using System;
using System.Text.RegularExpressions;

public class LogParser
{
    public bool IsValidLine(string text) => Regex.Match(text, @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]").Success;

    public string[] SplitLogLine(string text) => Regex.Split(text,@"<[\^*=-]*>");

    public int CountQuotedPasswords(string lines) => Regex.Matches(lines, @"\""((.)*password(.)*)\""", RegexOptions.IgnoreCase).Count; 

    public string RemoveEndOfLineText(string line) => Regex.Replace(line, @"end-of-line(\d)*", string.Empty);

    public string[] ListLinesWithPasswords(string[] lines)
    {
        var result = new string[lines.Length];

        for(int i=0; i<lines.Length; i++)
        {
            var match = Regex.Match(lines[i], @"password(\S+)",RegexOptions.IgnoreCase);
             result[i] =  $"{(match.Success ? match.Value : "--------")}: {lines[i]}";
        }

        return result;
    }
}


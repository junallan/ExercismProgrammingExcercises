using System;
using System.Text.RegularExpressions;

public class LogParser
{
    public bool IsValidLine(string text) => Regex.Match(text, @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]").Success;

    public string[] SplitLogLine(string text) => Regex.Split(text,@"<[\^*=-]*>");

    public int CountQuotedPasswords(string lines) => Regex.Matches(lines, @"\""((.)*password(.)*)\""", RegexOptions.IgnoreCase).Count; 

    public string RemoveEndOfLineText(string line)
    {
        throw new NotImplementedException($"Please implement the LogParser.RemoveEndOfLineText() method");
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        throw new NotImplementedException($"Please implement the LogParser.ListLinesWithPasswords() method");
    }
}

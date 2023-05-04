using System;
using System.Text;
using System.Text.RegularExpressions;

public static class Markdown
{
    private static string Wrap(string text, string tag)
    {
        var result = new StringBuilder();
        result.Append("<");
        result.Append(tag);
        result.Append(">");
        result.Append(text);
        result.Append("</");
        result.Append(tag);
        result.Append(">");

        return result.ToString();
    }

    private static bool IsTag(string text, string tag) => text.StartsWith($"<{tag}>");

    private static string Parse(string markdown, string delimiter, string tag)
    {
        var pattern = new StringBuilder();
        pattern.Append(delimiter);
        pattern.Append("(.+)");
        pattern.Append(delimiter);

        var replacement = new StringBuilder();
        replacement.Append("<");
        replacement.Append(tag);
        replacement.Append(">$1</");
        replacement.Append(tag);
        replacement.Append(">");

        return Regex.Replace(markdown, pattern.ToString(), replacement.ToString());
    }

    private static string Parse__(string markdown) => Parse(markdown, "__", "strong");

    private static string Parse_(string markdown) => Parse(markdown, "_", "em");

    private static string ParseText(string markdown, bool list)
    {
        var parsedText = Parse_(Parse__((markdown)));

        if (list) return parsedText;
        else return Wrap(parsedText, "p");
    }


    private static string ParseHeader(string markdown, bool list, out bool inListAfter)
    {
        var count = 0;
        for (int i = 0; i < markdown.Length; i++)
        {
            if (markdown[i] == '#')
            {
                count += 1;
            }
            else
            {
                break;
            }
        }
        if (count == 0 || count > 6)
        {
            inListAfter = list;
            return null;
        }
        var headerTag = new StringBuilder("h");
        headerTag.Append(count);

        var headerHtml = new StringBuilder(Wrap(markdown.Substring(count + 1), headerTag.ToString()));

        inListAfter = false;

        if (list) headerHtml.Insert(0, headerHtml);

        return headerHtml.ToString();
    }


    private static string ParseLineItem(string markdown, bool list, out bool inListAfter)
    {
        if (markdown.StartsWith("*"))
        {
            var innerHtml = Wrap(ParseText(markdown.Substring(2), true), "li");
            inListAfter = true;
            return list ? innerHtml : $"<ul>{innerHtml}";
        }
        inListAfter = list;
        return null;
    }


    private static string ParseParagraph(string markdown, bool list, out bool inListAfter)
    {
        inListAfter = false;

        var parseText = new StringBuilder(ParseText(markdown, false));

        if (list) parseText.Insert(0, "</ul>");

        return parseText.ToString();
    }

    private static string ParseLine(string markdown, bool list, out bool inListAfter)
         => ParseHeader(markdown, list, out inListAfter)
             ?? ParseLineItem(markdown, list, out inListAfter)
             ?? ParseParagraph(markdown, list, out inListAfter)
             ?? throw new ArgumentException("Invalid markdown");


    public static string Parse(string markdown)
    {
        var result = new StringBuilder();

        var lines = markdown.Split('\n');
        var list = false;

        for (int i = 0; i < lines.Length; i++)
        {
            result.Append(ParseLine(lines[i], list, out list));
        }

        if (list) result.Append("</ul>");

        return result.ToString();
    }
}
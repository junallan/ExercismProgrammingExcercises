using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        StringBuilder encodedInput = new StringBuilder();
        string pattern = @"(.)\1*";
        Regex regex = new Regex(pattern);

        foreach(Match match in regex.Matches(input))
        {
            encodedInput.Append(match.Value.Length == 1 ? match.Value : $"{match.Value.Length}{match.Value.First()}");
        }

        return encodedInput.ToString();
    }

    private static bool IsLetterOrWhiteSpace(this char input) => Char.IsLetter(input) || Char.IsWhiteSpace(input);

    public static string Decode(string input)
    {
        StringBuilder decodedInput = new StringBuilder();
        string pattern = @"(\d+)?(\D)";
        Regex regex = new Regex(pattern);

        foreach (Match match in regex.Matches(input))
        {
            var numberGroupValue = match.Groups[1].Value;
            var letterGroupValue = match.Groups[2].Value;

            decodedInput.Append(new String(letterGroupValue.First(), string.IsNullOrEmpty(numberGroupValue) ? 1 : int.Parse(numberGroupValue)));
        }

        return decodedInput.ToString();
    }
}

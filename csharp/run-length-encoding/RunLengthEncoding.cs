using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        StringBuilder encodedInput = new StringBuilder();
        string pattern = @"(.)\1{0,}";
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

            if (string.IsNullOrEmpty(numberGroupValue)) decodedInput.Append(letterGroupValue);
            else decodedInput.Insert(decodedInput.Length, letterGroupValue, int.Parse(numberGroupValue));
        }


        return decodedInput.ToString();
    }
}

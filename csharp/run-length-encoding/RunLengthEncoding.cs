using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        if (input.Length == 0) return string.Empty;

        StringBuilder encodedInput = new StringBuilder();
        int numberOfRepeatedInput = 1;

        for(int i=1; i<input.Length; i++)
        {
            if(input[i-1] == input[i])
                numberOfRepeatedInput++;
            else
            {              
                encodedInput.Append($"{((numberOfRepeatedInput == 1) ? string.Empty : numberOfRepeatedInput)}{input[i-1]}");

                numberOfRepeatedInput = 1;
            }
        }

        if(input.ElementAt(input.Length -2) == input.Last())
            encodedInput.Append($"{numberOfRepeatedInput}{input.Last()}");
        else
            encodedInput.Append(input.Last());

        return encodedInput.ToString();
    }

    private static bool IsLetterOrWhiteSpace(this char input) => Char.IsLetter(input) || Char.IsWhiteSpace(input);

    public static string Decode(string input)
    {
        StringBuilder decodedInput = new StringBuilder();

        string pattern = @"(\d+)?(\D)";//"(\\d+)*([a-zA-Z ]+)";

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

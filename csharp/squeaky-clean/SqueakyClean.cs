using System;
using System.Text;

public static class Identifier
{
    private static bool IsGreekLetter(char letter) => letter is >= 'α' and <= 'ω';
    private static bool ShouldConvertToKebabCase(string identifier, int i) => (i > 0) && identifier[i - 1] == '-';

    public static string Clean(string identifier)
    { 
        var identifierFiltered = new StringBuilder();

        for(int i=0; i < identifier.Length; i++)
        {
            identifierFiltered.Append(identifier[i] switch
            {
                _ when Char.IsWhiteSpace(identifier[i]) => "_",
                _ when Char.IsControl(identifier[i]) => "CTRL",
                _ when ShouldConvertToKebabCase(identifier, i)  => Char.ToUpper(identifier[i]).ToString(),
                _ when Char.IsLetter(identifier[i]) && !IsGreekLetter(identifier[i]) => identifier[i],
                _ => ""
            });
        }

      return identifierFiltered.ToString();
    }
}

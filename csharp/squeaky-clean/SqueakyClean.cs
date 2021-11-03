﻿using System;
using System.Linq;
using System.Text;

public static class Identifier
{
    private static bool IsGreekLetter(char letter) => letter is >= 'α' and <= 'ω';
    private static bool IsConvertToKebabCase(string identifier, int i) => (i > 0) && identifier[i - 1] == '-';

    public static string Clean(string identifier)
    { 
        StringBuilder identifierFiltered = new StringBuilder();

        for(int i=0; i< identifier.Length; i++)
        {
            if (identifier[i] == ' ') identifierFiltered.Append("_");
            else if (identifier[i] == '\0') identifierFiltered.Append("CTRL");
            else if (IsConvertToKebabCase(identifier, i)) identifierFiltered.Append(Char.ToUpper(identifier[i]));    
            else if (Char.IsLetter(identifier[i]) && !IsGreekLetter(identifier[i])) identifierFiltered.Append(identifier[i]);
        }

        return identifierFiltered.ToString();
    }

  
}

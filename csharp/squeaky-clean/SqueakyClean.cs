using System;
using System.Linq;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        //var identifierFiltered = identifier.Replace(' ', '_').Replace("\0", "CTRL");

        StringBuilder identifierFiltered = new StringBuilder();

        for(int i=0; i< identifier.Length; i++)
        {
            if (identifier[i] == ' ') identifierFiltered.Append("_");
            else if (identifier[i] == '\0') identifierFiltered.Append("CTRL");
            else if ((i > 0) && identifier[i - 1] == '-')
            {
                identifierFiltered.Append(Char.ToUpper(identifier[i]));
            }
            else if (Char.IsLetter(identifier[i])) identifierFiltered.Append(identifier[i]);
        }

        return identifierFiltered.ToString();
        //return String.Concat(identifier.Replace(' ', '_').Replace("\0","CTRL").Where(element => Char.IsLetter(element) || element == '_' || element == '\0'));
    }
}

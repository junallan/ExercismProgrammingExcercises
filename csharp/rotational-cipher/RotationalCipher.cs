using System;
using System.Collections.Generic;
using System.Linq;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        const string alphabetLower = "abcdefghijklmnopqrstuvwxyz";
        string alphabetUpper = alphabetLower.ToUpper();
        char[] convertedText = new char[text.Length];

        for(int i=0; i< text.Length; i++)
        {
            if(alphabetLower.Contains(text[i]))
            {
                convertedText[i] = alphabetLower.ElementAt((alphabetLower.IndexOf(text[i]) + shiftKey) % alphabetLower.Length);
            }
            else if(alphabetUpper.Contains(text[i]))
            {
                convertedText[i] = alphabetUpper.ElementAt((alphabetUpper.IndexOf(text[i]) + shiftKey) % alphabetUpper.Length);
            }
            else
            {
                convertedText[i] = text[i];
            }
        }

        return string.Concat(convertedText);
//        return new String(text.Select(letter => alphabet.ElementAt((alphabet.IndexOf(letter) + shiftKey) % alphabet.Length)).ToArray());
    }
}
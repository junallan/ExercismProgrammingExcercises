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
                convertedText[i] = LetterRotation(text[i], shiftKey, alphabetLower);
            }
            else if(alphabetUpper.Contains(text[i]))
            {
                convertedText[i] = LetterRotation(text[i], shiftKey, alphabetUpper);
            }
            else
            {
                convertedText[i] = text[i];
            }
        }

        return string.Concat(convertedText);
    }

    private static char LetterRotation(char letter, int shiftKey, string alphabetLower) => alphabetLower.ElementAt((alphabetLower.IndexOf(letter) + shiftKey) % alphabetLower.Length);
}
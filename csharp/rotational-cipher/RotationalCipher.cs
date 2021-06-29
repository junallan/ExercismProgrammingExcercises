using System;
using System.Collections.Generic;
using System.Linq;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        const string alphabetLower = "abcdefghijklmnopqrstuvwxyz";
        string alphabetUpper = alphabetLower.ToUpper();

        return string.Concat(text.Select(x => alphabetLower.Contains(x) ? 
                                    LetterRotation(x, shiftKey, alphabetLower) 
                                    : alphabetUpper.Contains(x.ToString()) ? 
                                        LetterRotation(x, shiftKey, alphabetUpper) 
                                        : x));
    }

    private static char LetterRotation(char letter, int shiftKey, string alphabetLower) => alphabetLower.ElementAt((alphabetLower.IndexOf(letter) + shiftKey) % alphabetLower.Length);
}
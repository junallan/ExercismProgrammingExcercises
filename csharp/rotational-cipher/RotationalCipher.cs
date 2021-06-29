using System;
using System.Collections.Generic;
using System.Linq;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        const string alphabetLower = "abcdefghijklmnopqrstuvwxyz";
        string alphabetUpper = alphabetLower.ToUpper();

        char LetterRotation(char c, string alphabet) => alphabet.ElementAt((alphabet.IndexOf(c) + shiftKey) % alphabet.Length);

        return string.Concat(text.Select(x => alphabetLower.Contains(x) ? 
                                    LetterRotation(x, alphabetLower) 
                                    : alphabetUpper.Contains(x.ToString()) ? 
                                        LetterRotation(x, alphabetUpper) 
                                        : x));
    }
}
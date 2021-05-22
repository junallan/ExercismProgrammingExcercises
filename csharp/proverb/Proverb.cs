using System;
using System.Collections.Generic;
using System.Linq;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        string[] messages = new string[subjects.Length];

        if (subjects.Length == 0) { return subjects; }

        return subjects.Zip(subjects.Skip(1), (firstSubject, secondSubject) => $"For want of a {firstSubject} the {secondSubject} was lost.")
                       .Append($"And all for the want of a {subjects[0]}.")
                       .ToArray();
    }
}
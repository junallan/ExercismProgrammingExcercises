using System;
using System.Collections.Generic;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        string[] messages = new string[subjects.Length];

        if (subjects.Length == 0) { return subjects; }

        for(int i=0; i<subjects.Length-1; i++)
        {
            messages[i] = $"For want of a {subjects[i]} the {subjects[i+1]} was lost.";
        }

        messages[subjects.Length-1] = $"And all for the want of a {subjects[0]}.";

        return messages;
    }
}
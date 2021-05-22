using System;
using System.Collections.Generic;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        List<string> messages = new List<string>();

        if (subjects.Length == 0) { return subjects; }

        for(int i=0; i<subjects.Length-1; i++)
        {
            messages.Add($"For want of a {subjects[i]} the {subjects[i+1]} was lost.");
        }

        messages.Add($"And all for the want of a {subjects[0]}.");

        return messages.ToArray();
    }
}
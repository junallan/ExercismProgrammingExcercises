using System;
using System.Collections.Generic;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (numbers == string.Empty 
                        || sliceLength <= 0 
                        || numbers.Length < sliceLength) 
        { 
            throw new ArgumentException(); 
        }
        
        List<string> series = new List<string>();

        for(var i=0; i<=numbers.Length-sliceLength; i++)
        {
            series.Add(numbers.Substring(i, sliceLength));
        }
        
       return series.ToArray();
    }
}
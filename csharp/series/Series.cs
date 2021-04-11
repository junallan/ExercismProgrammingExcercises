using System;
using System.Collections.Generic;
using System.Linq;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (sliceLength <= 0  || numbers.Length < sliceLength) 
        { 
            throw new ArgumentException(); 
        }

        return Enumerable.Range(0, numbers.Length+1-sliceLength).Select(i => numbers[i..(i+sliceLength)]).ToArray();
    }
}
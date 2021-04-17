using System;
using System.Text;

public static class Raindrops
{
    public static string Convert(int number)
    {
        Func<int, int, bool> isFactor = (int input, int divisbleFactor) => input % divisbleFactor == 0;

        bool isDivisbleBy3 = isFactor(number, 3);
        bool isDivisbleBy5 = isFactor(number, 5);
        bool isDivisbleBy7 = isFactor(number, 7);

        StringBuilder output = new StringBuilder();

        if(isDivisbleBy3)
        {
            output.Append("Pling");
        }

        if(isDivisbleBy5)
        {
            output.Append("Plang");
        }

        if(isDivisbleBy7)
        {
            output.Append("Plong");
        }

        return output.Length == 0 ? number.ToString() : output.ToString();
    }
}
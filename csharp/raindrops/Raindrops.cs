using System;
using System.Text;

public static class Raindrops
{
    public static string Convert(int number)
    {
        bool isDivisbleBy3 = IsFactor(number, 3);
        bool isDivisbleBy5 = IsFactor(number, 5);
        bool isDivisbleBy7 = IsFactor(number, 7);

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

    private static bool IsFactor(int input, int divisbleFactor)
    {
        return (input % divisbleFactor) == 0;
    }
}
using System;

public static class BinarySearch
{
    private const int NoValueFoundIndex = -1;

    public static int Find(int[] input, int value)
    {
        if (input.Length == 0) { return NoValueFoundIndex; }
        if (input.Length == 1) { return input[0] == value ? 0 : NoValueFoundIndex; }

        int middleIndex = input.Length / 2;

        if(input[middleIndex] == value) 
        { 
            return middleIndex;
        }
        else if(input[middleIndex] > value)
        {
            if (middleIndex - 1 == 0) { return input[0] == value ? 0 : NoValueFoundIndex; }

            return Find(input[..(middleIndex)], value);
        }
        else
        {
            if (middleIndex + 1 == input.Length) { return NoValueFoundIndex; }

            var indexAccumulation = middleIndex + 1;

            var subResulIndex = Find(input[(middleIndex + 1)..], value); ;

            if (subResulIndex == NoValueFoundIndex) { return NoValueFoundIndex; }

            return indexAccumulation + subResulIndex;
        }
    }
}
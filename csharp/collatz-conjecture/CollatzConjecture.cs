using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number <= 0) { throw new ArgumentOutOfRangeException(); }

        if (number == 1) { return 0; }

        return (number % 2) == 0 ? 1 + Steps(number / 2) : 1 + Steps(3 * number + 1);
    }
}
using System;
using System.Linq;

public static class Grains
{
    public static ulong Square(int n) => (n < 1 || n > 64) ? throw new ArgumentOutOfRangeException() : (ulong)Math.Pow(2, n - 1);
    public static ulong Total() => (ulong)Enumerable.Range(1, 64).Aggregate(0, (accum, val) => accum == 0 ? 1 : accum + (int)Square(val));
}
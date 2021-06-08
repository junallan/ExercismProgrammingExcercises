using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this extension method.");
    }
}

public struct RationalNumber
{
    public int Numerator { get; set; }
    public int Denominator { get; set; }

    public RationalNumber(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    private static int GreatestCommonDivisor(int numerator, int denominator)
    {
        if (numerator == 0 || (numerator == denominator)) { return denominator; }
        if (numerator == 1 || denominator == 1) { return 1; }

        int largestPossibleDivisor = numerator < denominator ? numerator / 2 : denominator / 2;

        bool isCommonDivisor = numerator % largestPossibleDivisor == 0 && denominator % largestPossibleDivisor == 0;
        while (!isCommonDivisor)
        {
            --largestPossibleDivisor;
            isCommonDivisor = numerator % largestPossibleDivisor == 0 && denominator % largestPossibleDivisor == 0;
        }

        return largestPossibleDivisor;

    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        var rationalNumber2Value = (decimal)r2.Numerator / r2.Denominator;
        int greatestCommonDivisor;

        if (rationalNumber2Value < 0)
        {
            var resultAbs = r2.Abs();

            greatestCommonDivisor = GreatestCommonDivisor(resultAbs.Numerator, resultAbs.Denominator);

            var result = r1 - r2.Abs();

            return new RationalNumber(result.Numerator / greatestCommonDivisor, result.Denominator / greatestCommonDivisor);
        }
       
        var numerator = (r1.Numerator * r2.Denominator + r1.Denominator * r2.Numerator);
        var denominator = (r2.Numerator * r2.Denominator);

        greatestCommonDivisor = GreatestCommonDivisor(Math.Abs(numerator), Math.Abs(denominator));

        return new RationalNumber(numerator, denominator);
    }

 
    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        var rationalNumber2Value = (decimal)r2.Numerator / r2.Denominator;
        int greatestCommonDivisor;

        if (rationalNumber2Value < 0)
        {
            var resultAbs = r2.Abs();
            greatestCommonDivisor = GreatestCommonDivisor(resultAbs.Numerator, resultAbs.Denominator);

            var result = r1 + r2.Abs();

            return new RationalNumber(result.Numerator / greatestCommonDivisor, result.Denominator / greatestCommonDivisor);
        }

        var numerator = r1.Numerator * r2.Denominator - r1.Denominator * r2.Numerator;
        var denominator = r2.Numerator * r2.Denominator;

        greatestCommonDivisor = GreatestCommonDivisor(Math.Abs(numerator), Math.Abs(denominator));

        return new RationalNumber(numerator / greatestCommonDivisor, denominator / greatestCommonDivisor);
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        throw new NotImplementedException("You need to implement this operator.");
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        throw new NotImplementedException("You need to implement this operator.");
    }

    public RationalNumber Abs()
    {
        var numerator = Numerator < 0 ? Numerator * -1 : Numerator;
        var denominator = Denominator < 0 ? Denominator * -1 : Denominator;

        return new RationalNumber(numerator, denominator);
    }

    public RationalNumber Reduce()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public RationalNumber Exprational(int power)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public double Expreal(int baseNumber)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
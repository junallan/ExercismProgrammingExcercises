using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r) => r.Expreal(realNumber);
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
     
        int largestPossibleDivisor = numerator < denominator ? numerator : denominator;

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
        if (((decimal)r2.Numerator / r2.Denominator) < 0)
        {
            return (r1 - r2.Abs()).Reduce(); 
        }
       
        var numerator = (r1.Numerator * r2.Denominator + r1.Denominator * r2.Numerator);
        var denominator = (r2.Numerator * r2.Denominator);

        return new RationalNumber(numerator, denominator).Reduce();
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
        var numerator = r1.Numerator * r2.Numerator;
        var denominator = r1.Denominator * r2.Denominator;

        int greatestCommonDivisor = GreatestCommonDivisor(Math.Abs(numerator), Math.Abs(denominator));

        return new RationalNumber(numerator / greatestCommonDivisor, denominator / greatestCommonDivisor);
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        var numerator = r1.Numerator * r2.Denominator;
        var denominator = r2.Numerator * r1.Denominator;

        int greatestCommonDivisor = GreatestCommonDivisor(Math.Abs(numerator), Math.Abs(denominator));
        
        if (numerator > 0 && denominator < 0)
        {
            numerator *= -1;
            denominator *= -1;
        }
        else if(numerator < 0 && denominator < 0)
        {
            numerator *= -1;
            denominator *= -1;
        }

        return new RationalNumber(numerator / greatestCommonDivisor, denominator / greatestCommonDivisor);
    }

    public RationalNumber Abs()
    {
        var numerator = Numerator < 0 ? Numerator * -1 : Numerator;
        var denominator = Denominator < 0 ? Denominator * -1 : Denominator;

        return new RationalNumber(numerator, denominator);
    }

    public RationalNumber Reduce()
    {
        var absRational = this.Abs();
        var greatestCommonDivisor = GreatestCommonDivisor(absRational.Numerator, absRational.Denominator);

        if(Numerator > 0 && Denominator < 0)
        {
            Numerator *= -1;
            Denominator *= -1;
        }

        return new RationalNumber(Numerator / greatestCommonDivisor, Denominator / greatestCommonDivisor);
    }

    public RationalNumber Exprational(int power) => new RationalNumber((int)Math.Pow(Numerator, power), (int)Math.Pow(Denominator, power));

    public double Expreal(int baseNumber) => Math.Pow(Math.Pow(baseNumber, Numerator), (double)1 / Denominator);
}
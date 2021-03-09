using System;

public static class Darts
{
    static (int RadiusSquared, int Score) InnerRegion => (1, 10);
    static (int RadiusSquared, int Score) MiddleRegion => (25, 5);
    static (int RadiusSquared, int Score) OuterRegion => (100, 1);

    public static int Score(double x, double y)
    {
        var radiusSquaredOfThrow = Math.Pow(x, 2) + Math.Pow(y, 2);

        if(radiusSquaredOfThrow <= InnerRegion.RadiusSquared) { return InnerRegion.Score;}
        else if(radiusSquaredOfThrow <= MiddleRegion.RadiusSquared) { return MiddleRegion.Score; }
        else if(radiusSquaredOfThrow <= OuterRegion.RadiusSquared) { return OuterRegion.Score; }
        else { return 0; }
    }
}

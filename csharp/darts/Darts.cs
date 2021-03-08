using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
        var radiusSquaredOfThrow = Math.Pow(x, 2) + Math.Pow(y, 2);

        var dartBoard = new DartBoard();

        if(radiusSquaredOfThrow <= dartBoard.InnerRegion.RadiusSquared) { return dartBoard.InnerRegion.Score;}
        else if(radiusSquaredOfThrow <= dartBoard.MiddleRegion.RadiusSquared) { return dartBoard.MiddleRegion.Score; }
        else if(radiusSquaredOfThrow <= dartBoard.OuterRegion.RadiusSquared) { return dartBoard.OuterRegion.Score; }
        else { return 0; }
    }

    public class DartBoard
    {
        public Region InnerRegion => new Region { RadiusSquared = 1, Score = 10 };
        public Region MiddleRegion => new Region { RadiusSquared = 25, Score = 5 };
        public Region OuterRegion => new Region { RadiusSquared = 100, Score = 1 };
    }

    public class Region
    {
        public int RadiusSquared { get; set; }
        public int Score { get; set; }
    }
}

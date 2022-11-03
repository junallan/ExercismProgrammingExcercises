using System;
using System.Collections.Generic;
using System.Linq;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    public Coord TopLeft{ get; set; }
    public Coord BottomLeft{ get; set; }
    public Coord TopRight{ get; set; }
    public Coord BottomRight{ get; set; }

    public Plot(Coord topLeft, Coord bottomLeft, Coord topRight, Coord bottomRight)
    {
        TopLeft = topLeft;
        BottomLeft = bottomLeft;
        TopRight = topRight;
        BottomRight = bottomRight;       
    }
}


public class ClaimsHandler
{
    public HashSet<Plot> Plots{ get; set; } = new HashSet<Plot>();

    public void StakeClaim(Plot plot)
    {
        Plots.Add(plot);
    }

    public bool IsClaimStaked(Plot plot) => Plots.Contains(plot);

    public bool IsLastClaim(Plot plot) => Plots.Last().Equals(plot);

    public Plot GetClaimWithLongestSide()
    {  
        Plot longestSidePlot = Plots.First();
        double currentLongestLength = 0;

        foreach(var plot in Plots)
        {
            double plotLongestSide = GetLongestSide(plot);

            if((currentLongestLength == 0) || (currentLongestLength < plotLongestSide))
            {
                currentLongestLength = plotLongestSide;
                longestSidePlot = plot;
            }
        }
       
        return longestSidePlot;
    }

    private double GetLongestSide(Plot plot)
    {
        var topSide = GetCoordinateLength(plot.TopLeft, plot.TopRight);
        var bottomSide = GetCoordinateLength(plot.BottomLeft, plot.BottomRight);
        var leftSide = GetCoordinateLength(plot.TopLeft, plot.BottomLeft);
        var rightSide = GetCoordinateLength(plot.TopRight, plot.BottomRight);

        return new[]{ topSide, bottomSide, leftSide, rightSide}.Max();
    }

    private double GetCoordinateLength(Coord coord1, Coord coord2)
    {
        int xPlane = coord2.X-coord1.X;
        int yPlane = coord2.Y-coord1.Y;

        return Math.Sqrt(Math.Pow(xPlane, 2) + Math.Pow(yPlane, 2));
    }
}

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
    public List<Plot> Plots{ get; set; } = new List<Plot>();

    public void StakeClaim(Plot plot)
    {
        Plots.Add(plot);
    }

    public bool IsClaimStaked(Plot plot) => Plots.Any(section => section.TopLeft.X == plot.TopLeft.X && section.TopLeft.Y == plot.TopLeft.Y &&
                                                                section.BottomLeft.X == plot.BottomLeft.X && section.BottomLeft.Y == plot.BottomLeft.Y &&
                                                                section.TopRight.X == plot.TopRight.X && section.TopRight.Y == plot.TopRight.Y &&
                                                                section.BottomRight.X == plot.BottomRight.X && section.BottomRight.Y == plot.BottomRight.Y);

    public bool IsLastClaim(Plot plot)
    {
        var lastPlotItem = Plots.Last();
        return GetCoordinateLength(lastPlotItem.TopLeft, plot.TopLeft) == 0 && GetCoordinateLength(lastPlotItem.BottomLeft, plot.BottomLeft) == 0
             && GetCoordinateLength(lastPlotItem.TopRight, plot.TopRight) == 0 && GetCoordinateLength(lastPlotItem.BottomRight, plot.BottomRight) == 0;
    } 

    public Plot GetClaimWithLongestSide()
    {  
        int longestSideIndex = 0;
        double currentLongestLength = 0;

        for(int i=0; i<Plots.Count; i++)
        {
            if(currentLongestLength == 0) currentLongestLength = GetCoordinateLength(Plots[i].TopLeft, Plots[i].BottomLeft);
            
            double coordinateLength = GetCoordinateLength(Plots[i].TopLeft, Plots[i].BottomLeft);
            
            if(currentLongestLength < coordinateLength)
            {
                currentLongestLength = coordinateLength;
                longestSideIndex = i;
                continue;
            }

            coordinateLength = GetCoordinateLength(Plots[i].TopLeft, Plots[i].TopRight);

            if(currentLongestLength < coordinateLength)
            {
                currentLongestLength = coordinateLength;
                longestSideIndex = i;
                continue;
            }

            coordinateLength = GetCoordinateLength(Plots[i].TopLeft, Plots[i].BottomRight);

            if(currentLongestLength < coordinateLength)
            {
                currentLongestLength = coordinateLength;
                longestSideIndex = i;
                continue;
            }

            coordinateLength = GetCoordinateLength(Plots[i].BottomLeft, Plots[i].TopRight);

            if(currentLongestLength < coordinateLength)
            {
                currentLongestLength = coordinateLength;
                longestSideIndex = i;
                continue;
            }

            coordinateLength = GetCoordinateLength(Plots[i].BottomLeft, Plots[i].BottomRight);

            if(currentLongestLength < coordinateLength)
            {
                currentLongestLength = coordinateLength;
                longestSideIndex = i;
                continue;
            }

            coordinateLength = GetCoordinateLength(Plots[i].TopRight, Plots[i].BottomRight);

            if(currentLongestLength < coordinateLength)
            {
                currentLongestLength = coordinateLength;
                longestSideIndex = i;
                continue;
            }
        }
       
        return Plots[longestSideIndex];
    }

    private double GetCoordinateLength(Coord coord1, Coord coord2)
    {
        int xPlane = coord2.X-coord1.X;
        int yPlane = coord2.Y-coord1.Y;

        return Math.Sqrt(Math.Pow(xPlane, 2) + Math.Pow(yPlane, 2));
    }
}

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
        int longestSideIndex = 0;
        double currentLongestLength = 0;

        for(int i=0; i<Plots.Count; i++)
        {
            if(currentLongestLength == 0) currentLongestLength = GetCoordinateLength(Plots.ElementAt(i).TopLeft, Plots.ElementAt(i).BottomLeft);
            
            double coordinateLength = GetCoordinateLength(Plots.ElementAt(i).TopLeft, Plots.ElementAt(i).BottomLeft);
            
            if(currentLongestLength < coordinateLength)
            {
                currentLongestLength = coordinateLength;
                longestSideIndex = i;
                continue;
            }

            coordinateLength = GetCoordinateLength(Plots.ElementAt(i).TopLeft, Plots.ElementAt(i).TopRight);

            if(currentLongestLength < coordinateLength)
            {
                currentLongestLength = coordinateLength;
                longestSideIndex = i;
                continue;
            }

            coordinateLength = GetCoordinateLength(Plots.ElementAt(i).TopLeft, Plots.ElementAt(i).BottomRight);

            if(currentLongestLength < coordinateLength)
            {
                currentLongestLength = coordinateLength;
                longestSideIndex = i;
                continue;
            }

            coordinateLength = GetCoordinateLength(Plots.ElementAt(i).BottomLeft, Plots.ElementAt(i).TopRight);

            if(currentLongestLength < coordinateLength)
            {
                currentLongestLength = coordinateLength;
                longestSideIndex = i;
                continue;
            }

            coordinateLength = GetCoordinateLength(Plots.ElementAt(i).BottomLeft, Plots.ElementAt(i).BottomRight);

            if(currentLongestLength < coordinateLength)
            {
                currentLongestLength = coordinateLength;
                longestSideIndex = i;
                continue;
            }

            coordinateLength = GetCoordinateLength(Plots.ElementAt(i).TopRight, Plots.ElementAt(i).BottomRight);

            if(currentLongestLength < coordinateLength)
            {
                currentLongestLength = coordinateLength;
                longestSideIndex = i;
                continue;
            }
        }
       
        return Plots.ElementAt(longestSideIndex);
    }

    private double GetCoordinateLength(Coord coord1, Coord coord2)
    {
        int xPlane = coord2.X-coord1.X;
        int yPlane = coord2.Y-coord1.Y;

        return Math.Sqrt(Math.Pow(xPlane, 2) + Math.Pow(yPlane, 2));
    }
}

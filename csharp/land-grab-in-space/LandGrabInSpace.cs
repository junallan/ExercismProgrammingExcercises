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
    public Coord C1{ get; set; }
    public Coord C2{ get; set; }
    public Coord C3{ get; set; }
    public Coord C4{ get; set; }
    public Plot(Coord c1, Coord c2, Coord c3, Coord c4)
    {
        C1 = c1;
        C2 = c2;
        C3 = c3;
        C4 = c4;       
    }
}


public class ClaimsHandler
{
    public List<Plot> Plots{ get; set; } = new List<Plot>();

    public void StakeClaim(Plot plot)
    {
        Plots.Add(plot);
    }

    public bool IsClaimStaked(Plot plot)
    {
        bool isStaked = false;

        foreach(var section in Plots)
        {
            if(section.C1.X == plot.C1.X && section.C1.Y == plot.C1.Y && 
                section.C2.X == plot.C2.X && section.C2.Y == plot.C2.Y && 
                section.C3.X == plot.C3.X && section.C3.Y == plot.C3.Y &&
                section.C4.X == plot.C4.X && section.C4.Y == plot.C4.Y)
            {
                isStaked = true;
                break;
            }
        }

        return isStaked;
    }
        

    public bool IsLastClaim(Plot plot)
    {
        var lastPlotItem = Plots.Last();
        return GetCoordinateLength(lastPlotItem.C1, plot.C1) == 0 && GetCoordinateLength(lastPlotItem.C2, plot.C2) == 0
             && GetCoordinateLength(lastPlotItem.C3, plot.C3) == 0 && GetCoordinateLength(lastPlotItem.C4, plot.C4) == 0;
    } 

    public Plot GetClaimWithLongestSide()
    {  
        int longestSideIndex = 0;
        double currentLongestLength = 0;

        for(int i=0; i<Plots.Count; i++)
        {
            if(currentLongestLength == 0) currentLongestLength = GetCoordinateLength(Plots[i].C1, Plots[i].C2);
            
            double coordinateLength = GetCoordinateLength(Plots[i].C1, Plots[i].C2);
            
            if(currentLongestLength < coordinateLength)
            {
                currentLongestLength = coordinateLength;
                longestSideIndex = i;
                continue;
            }

            coordinateLength = GetCoordinateLength(Plots[i].C1, Plots[i].C3);

            if(currentLongestLength < coordinateLength)
            {
                currentLongestLength = coordinateLength;
                longestSideIndex = i;
                continue;
            }

            coordinateLength = GetCoordinateLength(Plots[i].C1, Plots[i].C4);

            if(currentLongestLength < coordinateLength)
            {
                currentLongestLength = coordinateLength;
                longestSideIndex = i;
                continue;
            }

            coordinateLength = GetCoordinateLength(Plots[i].C2, Plots[i].C3);

            if(currentLongestLength < coordinateLength)
            {
                currentLongestLength = coordinateLength;
                longestSideIndex = i;
                continue;
            }

            coordinateLength = GetCoordinateLength(Plots[i].C2, Plots[i].C4);

            if(currentLongestLength < coordinateLength)
            {
                currentLongestLength = coordinateLength;
                longestSideIndex = i;
                continue;
            }

            coordinateLength = GetCoordinateLength(Plots[i].C3, Plots[i].C4);

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

using System;

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
    public Plot Plot{ get; set; }

    public void StakeClaim(Plot plot)
    {
        Plot = plot;
    }

    public bool IsClaimStaked(Plot plot) => 
        Plot.C1.X == plot.C1.X && Plot.C1.Y == plot.C1.Y && 
        Plot.C2.X == plot.C2.X && Plot.C2.Y == plot.C2.Y && 
        Plot.C3.X == plot.C3.X && Plot.C3.Y == plot.C3.Y &&
        Plot.C4.X == plot.C4.X && Plot.C4.Y == plot.C4.Y;

    public bool IsLastClaim(Plot plot) => IsClaimStaked(plot);

    public Plot GetClaimWithLongestSide()
    {
        throw new NotImplementedException("Please implement the ClaimsHandler.GetClaimWithLongestSide() method");
    }
}

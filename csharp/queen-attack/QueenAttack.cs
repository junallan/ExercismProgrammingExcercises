using System;

public class Queen
{
    public Queen(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }

    public const int MaxDimension = 7;
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black)
    {
        return (white, black) switch
        {
            (Queen w, Queen b) when w.Column == b.Column || w.Row == b.Row                   => true,
            (Queen w, Queen b) when Math.Abs(w.Column - b.Column) == Math.Abs(w.Row - b.Row) => true,
            _                                                                                => false
        };
    }

    public static Queen Create(int row, int column) =>
        (row < 0 || row > Queen.MaxDimension || column < 0 || column > Queen.MaxDimension) 
            ? throw new ArgumentOutOfRangeException() : new Queen(row, column);
    
}
using System;
using System.Linq;

public class Matrix
{
    private int[][] _matrix;

    public Matrix(string input) => _matrix = input.Split('\n')
                                                  .Select(row => row.Split(' ')
                                                                    .Select(column => int.Parse(column))
                                                                    .ToArray())
                                                  .ToArray();

    public int Rows => _matrix.Length;

    public int Cols => _matrix.First().Length;

    public int[] Row(int row) => Enumerable.Range(0, Cols).Select(x => _matrix[row - 1][x]).ToArray();

    public int[] Column(int col) => Enumerable.Range(0, Rows).Select(x => _matrix[x][col - 1]).ToArray();
}
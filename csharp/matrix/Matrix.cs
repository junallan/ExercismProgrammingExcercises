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

    public int[] Row(int row) => _matrix[row - 1];

    public int[] Column(int col) => _matrix.Select(row => row[col - 1]).ToArray(); 
}
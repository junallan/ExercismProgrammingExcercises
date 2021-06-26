using System;
using System.Linq;

public class Matrix
{
    private int[,] _matrix;

    public Matrix(string input)
    {
        var rowElements = input.Split("\n");
        int columnLength = rowElements[0].Split(" ").Length;

        _matrix = new int[rowElements.Length, columnLength];

        for(int i=0; i < rowElements.Length; i++)
        {
            var columnElements = rowElements[i].Split(" ");

            for(int j=0; j < columnElements.Length; j++)
            {
                _matrix[i,j] = int.Parse(columnElements[j]);
            }
        }
    }

    public int Rows => _matrix.GetLength(0);

    public int Cols => _matrix.GetLength(1);

    public int[] Row(int row) => Enumerable.Range(0, Cols).Select(x => _matrix[row - 1, x]).ToArray();

    public int[] Column(int col) => Enumerable.Range(0, Rows).Select(x => _matrix[x, col - 1]).ToArray();
}
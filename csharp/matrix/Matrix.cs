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

    public int Rows
    {
        get
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }

    public int Cols
    {
        get
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }

    public int[] Row(int row)
    {
        return Enumerable.Range(0, _matrix.GetLength(1)).Select(x => _matrix[row - 1, x]).ToArray();
    }

    public int[] Column(int col)
    {
        return Enumerable.Range(0, _matrix.GetLength(0)).Select(x => _matrix[x, col - 1]).ToArray();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        var potentialSaddlePointCoordinates = new List<Tuple<int, int>>();

        for(int rowIndex=0; rowIndex<matrix.GetLength(0); rowIndex++)
        {
            var rowValues = GetRow(matrix, rowIndex);

            var maxRowValue = rowValues.Max();

            var columnIndexMaxValue = Array.IndexOf(rowValues, maxRowValue);

            var columnValues = GetColumn(matrix, columnIndexMaxValue);
            var minColumnValue = columnValues.Min();

            var rowIndexMinValue = Array.IndexOf(columnValues, minColumnValue);
        }

        return null;
        //for (int row=0; row<matrix.GetLength(0); row++)
        //{
        //    int maxValue = 0;
 
        //    for(int column=0; column<matrix.GetLength(1); column++)
        //    {
        //        if (matrix[row, column] > maxValue) 
        //        {
        //            potentialSaddlePointCoordinates.Clear();
        //            potentialSaddlePointCoordinates.Add(Tuple.Create(row, column));
        //        }
        //        else if(matrix[row, column] == maxValue)
        //        {
        //            potentialSaddlePointCoordinates.Add(Tuple.Create(row, column));
        //        }
        //    }  
        //}

        //potentialS
    }

    public static int[] GetColumn(int[,] matrix, int columnNumber)
    {
        return Enumerable.Range(0, matrix.GetLength(0))
                         .Select(x => matrix[x, columnNumber])
                         .ToArray();
    }

    public static int[] GetRow(int[,] matrix, int rowNumber)
    {
        return Enumerable.Range(0, matrix.GetLength(1))
                         .Select(x => matrix[rowNumber, x])
                         .ToArray();
    }

}

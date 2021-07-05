using System;
using System.Collections.Generic;
using System.Linq;

public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        var saddlePointCoordinates = new HashSet<(int,int)>();

        for(int rowIndex=0; rowIndex<matrix.GetLength(0); rowIndex++)
        {
            var rowValues = GetRow(matrix, rowIndex);
            var maxRowValue = rowValues.Max();
            var maxRowData = rowValues.Select((value, index) => (value, index)).Where(x => x.value == maxRowValue);

            foreach(var item in maxRowData)
            {
                var columnValues = GetColumn(matrix, item.index);
                var minColumnValue = columnValues.Min();

                if(maxRowValue == minColumnValue)
                {
                    var minColumnData = columnValues.Select((value, index) => (value, index)).Where(x => x.value == minColumnValue);

                    minColumnData.ToList().ForEach(x => saddlePointCoordinates.Add((rowIndex + 1, item.index + 1)));
                }          
            }
        }

        return saddlePointCoordinates;
    }

    public static int[] GetColumn(int[,] matrix, int columnNumber) => Enumerable.Range(0, matrix.GetLength(0))
                                                                                .Select(x => matrix[x, columnNumber])
                                                                                .ToArray();

    public static int[] GetRow(int[,] matrix, int rowNumber) => Enumerable.Range(0, matrix.GetLength(1))
                                                                          .Select(x => matrix[rowNumber, x])
                                                                          .ToArray();
}

using System;
using System.Linq;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) 
    {
        if (span > digits.Length) { throw new ArgumentException(); }
        if (span == 0 /*&& digits == string.Empty*/) { return 1; }

        long result = 0;

        long substringProduct(int startIndex, int endIndex) => digits.Substring(startIndex, endIndex)
                                                                     .Select(d => Convert.ToInt64(d.ToString()))
                                                                     .Aggregate((product, val) => product * val);

        for (int i=0; i+span-1<digits.Length; i++)
        {
            long currentProduct = substringProduct(i, span);

            if(result < currentProduct)
            {
                result = currentProduct;
            }
        }

        return result;
    }
}
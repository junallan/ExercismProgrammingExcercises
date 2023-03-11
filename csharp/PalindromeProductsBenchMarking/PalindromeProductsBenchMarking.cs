using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace PalindromeProductsBenchMarking
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class PalindromeProductsBenchMarking
    {
        //[Benchmark]
        //public void MeasureSmallest()
        //{
        //    PalindromeProducts.Smallest(100, 999);
        //}

        //[Benchmark]
        //public void MeasureSmallestBetweenSquareRange()
        //{
        //    PalindromeProducts.SmallestVariationBetweenSquareRange(100, 999);
        //}

        [Benchmark]
        public void MeasureLargest()
        {
            PalindromeProducts.Largest(100, 999);
        }

        [Benchmark]
        public void MeasureLargestBetweenSquareRangeV1()
        {
           PalindromeProducts.LargestVariationBetweenSquareRangeV1(100, 999);
        }

        [Benchmark]
        public void MeasureLargestBetweenSquareRangeV2()
        {
            PalindromeProducts.LargestVariationBetweenSquareRangeV2(100, 999);
        }
    }
}
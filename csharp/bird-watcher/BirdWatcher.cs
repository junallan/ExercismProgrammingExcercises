using System;
using System.Linq;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return new [] { 0, 2, 5, 3, 7, 8, 4 };
    }

    public int Today() => this.birdsPerDay.Last();

    public void IncrementTodaysCount()
    {
        for(int i=0; i<this.birdsPerDay.Length; i++)
            this.birdsPerDay[i]++;
    }

    public bool HasDayWithoutBirds()
    {
        return this.birdsPerDay.Any(c => c == 0);
    }

    public int CountForFirstDays(int numberOfDays)
    {
        throw new NotImplementedException("Please implement the BirdCount.CountForFirstDays() method");
    }

    public int BusyDays()
    {
        throw new NotImplementedException("Please implement the BirdCount.BusyDays() method");
    }
}

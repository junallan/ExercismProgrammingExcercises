using System;
using System.Linq;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay) => this.birdsPerDay = birdsPerDay;

    public static int[] LastWeek() => new[] { 0, 2, 5, 3, 7, 8, 4 };

    public int Today() => this.birdsPerDay.Last();

    public void IncrementTodaysCount()
    {
        for(int i=0; i<this.birdsPerDay.Length; i++)
            this.birdsPerDay[i]++;
    }

    public bool HasDayWithoutBirds() => this.birdsPerDay.Any(c => c == 0);

    public int CountForFirstDays(int numberOfDays) => this.birdsPerDay[..numberOfDays].Sum();

    public int BusyDays()
    {
        throw new NotImplementedException("Please implement the BirdCount.BusyDays() method");
    }
}

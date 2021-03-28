using System;
using System.Collections.Generic;
using System.Linq;

public enum Schedule
{
    Teenth = 13,
    First = 1,
    Second = 8,
    Third = 15,
    Fourth = 22,
    Last
}

public class Meetup
{
    private readonly int _month;
    private readonly int _year;

    public Meetup(int month, int year)
    {
        _month = month;
        _year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        var daysInMonth = DateTime.DaysInMonth(_year, _month);
        DateTime startDate = new DateTime();

        startDate = new DateTime(_year, _month, (int)schedule);

        return schedule == Schedule.Last ? GetDateRange(new DateTime(_year, _month, (int)Schedule.Fourth), new DateTime(_year,_month, daysInMonth)).Where(x => x.DayOfWeek == dayOfWeek).Last() :
                                            GetDateRange(startDate, startDate.AddDays(6)).Where(x => x.DayOfWeek == dayOfWeek).Single();
    }

    private IEnumerable<DateTime> GetDateRange(DateTime startDate, DateTime endDate)
    {
        while(startDate <= endDate)
        {
            yield return startDate;
            startDate = startDate.AddDays(1);
        }
    }
}
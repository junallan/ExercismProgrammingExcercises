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
        
        return schedule == Schedule.Last ? Enumerable.Range((int)Schedule.Fourth, daysInMonth + 1 - (int)Schedule.Fourth)
                                                                .Select(day => new DateTime(_year, _month, day))
                                                                .Where(d => d.DayOfWeek == dayOfWeek).Last() :
                                           Enumerable.Range((int)schedule, 7)
                                                                .Select(day => new DateTime(_year, _month, day))
                                                                .Where(d => d.DayOfWeek == dayOfWeek).Single();
    }
}
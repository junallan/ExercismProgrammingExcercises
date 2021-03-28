using System;
using System.Collections.Generic;
using System.Linq;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
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
        List<int> dayRange = new List<int>();

        switch(schedule)
        {
            case Schedule.Teenth:
                dayRange.AddRange(Enumerable.Range(13, 7)); 
                break;
            case Schedule.First:
                dayRange.AddRange(Enumerable.Range(1, 7));
                break;
            case Schedule.Second:
                dayRange.AddRange(Enumerable.Range(8, 7));
                break;
            case Schedule.Third:
                dayRange.AddRange(Enumerable.Range(15, 7));
                break;
            case Schedule.Fourth:
            case Schedule.Last:
                dayRange.AddRange(Enumerable.Range(22, 7));
                if(schedule == Schedule.Last)
                {
                    int numberOfDaysPastFourthWeek = daysInMonth - 28;

                    if (numberOfDaysPastFourthWeek > 0)
                    {
                        dayRange.AddRange(Enumerable.Range(29, numberOfDaysPastFourthWeek));
                    }
                }

                break;
        }


        DateTime currentDate;
        int i = dayRange.Count-1;

        do
        {
            currentDate = new DateTime(_year, _month, dayRange[i--]);
        } while (currentDate.DayOfWeek != dayOfWeek);

        return currentDate;
    }
}
using System;


public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    private static TimeZoneInfo GetLocationTimeZone(Location location)
    {
        return TimeZoneInfo.FindSystemTimeZoneById(location switch
        {
            Location.NewYork => "Eastern Standard Time",
            Location.London => "GMT Standard Time",
            Location.Paris => "W. Europe Standard Time",
            _ => throw new NotImplementedException()
        });
    }

    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location) 
                            =>  TimeZoneInfo.ConvertTime(DateTime.Parse(appointmentDateDescription),
                                                         GetLocationTimeZone(location),
                                                         TimeZoneInfo.Utc);

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) => alertLevel switch
    {
        AlertLevel.Early => appointment.AddDays(-1),
        AlertLevel.Standard => appointment.AddHours(-1).AddMinutes(-45),
        AlertLevel.Late => appointment.AddMinutes(-30),
        _ => throw new NotImplementedException()
    };

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        //var locationTimeZone = GetLocationTimeZone(location);

        //return locationTimeZone.IsDaylightSavingTime(new DateTimeOffset(dt, TimeSpan.FromDays(7)));
        return TimeZoneInfo.ConvertTimeFromUtc(dt, GetLocationTimeZone(location)).IsDaylightSavingTime();


        //return Schedule(dt.ToString(), location).IsDaylightSavingTime();
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        throw new NotImplementedException("Please implement the (static) Appointment.NormalizeDateTime() method");
    }
}

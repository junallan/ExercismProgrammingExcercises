using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

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
    private static readonly int DayRangeInThePastToEvaluateDaylightSavingsTime = -7;
    private static readonly ReadOnlyCollection<TimeZoneInfo> TimeZones = TimeZoneInfo.GetSystemTimeZones();
    private static TimeZoneInfo GetLocationTimeZone(Location location) => location switch
    {
        Location.NewYork => TimeZones.Where(timeZone => timeZone.Id == "Eastern Standard Time" || timeZone.Id == "America/New_York").Single(),
        Location.London => TimeZones.Where(timeZone => timeZone.Id == "GMT Standard Time" || timeZone.Id == "Europe/London").Single(),
        Location.Paris => TimeZones.Where(timeZone => timeZone.Id == "W. Europe Standard Time" || timeZone.Id == "Europe/Paris").Single(),
        _ => throw new NotImplementedException()
    };
    private static CultureInfo GetLocationCulture(Location location) => location switch
    {
        Location.NewYork => new CultureInfo("en-US"),
        Location.London => new CultureInfo("en-GB"),
        Location.Paris => new CultureInfo("fr-FR"),
        _ => throw new NotImplementedException(),
    };

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
        var locationTimeZone = GetLocationTimeZone(location);

        return locationTimeZone.IsDaylightSavingTime(dt.AddDays(DayRangeInThePastToEvaluateDaylightSavingsTime)) != locationTimeZone.IsDaylightSavingTime(dt);
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        DateTime.TryParse(dtStr, GetLocationCulture(location).DateTimeFormat, DateTimeStyles.None, out DateTime localDate);

        return localDate;
    }
}

using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;

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
    private static readonly bool IsWindowsOperatingSystem = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    private static TimeZoneInfo GetLocationTimeZone(Location location) => location switch
    {
        Location.NewYork => TimeZoneInfo.FindSystemTimeZoneById(IsWindowsOperatingSystem ? "Eastern Standard Time" : "America/New_York"),
        Location.London => TimeZoneInfo.FindSystemTimeZoneById(IsWindowsOperatingSystem ? "GMT Standard Time" : "Europe/London"),
        Location.Paris => TimeZoneInfo.FindSystemTimeZoneById(IsWindowsOperatingSystem ? "W. Europe Standard Time" : "Europe/Paris"),
        _ => throw new NotImplementedException()
    };
    private static CultureInfo GetLocationCulture(Location location) => location switch
    {
        Location.NewYork => new CultureInfo("en-US"),
        Location.London => new CultureInfo("en-GB"),
        Location.Paris => new CultureInfo("fr-FR"),
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
    };

    public static bool HasDaylightSavingChanged(DateTime dt, Location location) => GetLocationTimeZone(location).IsDaylightSavingTime(dt.AddDays(DayRangeInThePastToEvaluateDaylightSavingsTime)) != GetLocationTimeZone(location).IsDaylightSavingTime(dt);

    public static DateTime NormalizeDateTime(string dtStr, Location location) => DateTime.TryParse(dtStr, GetLocationCulture(location).DateTimeFormat, DateTimeStyles.None, out DateTime localDate) ? localDate : localDate;
}

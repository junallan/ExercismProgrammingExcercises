using System;

static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription) => DateTime.Parse(appointmentDateDescription);

    public static bool HasPassed(DateTime appointmentDate) => DateTime.Now.CompareTo(appointmentDate) > 0;

    public static bool IsAfternoonAppointment(DateTime appointmentDate) => 12 <= appointmentDate.Hour && appointmentDate.Hour < 18;

    public static string Description(DateTime appointmentDate) => $"You have an appointment on {appointmentDate.ToString("M/d/yyyy h:mm:ss tt")}.";

    public static DateTime AnniversaryDate() => new DateTime(DateTime.Today.Year, 9, 15);
}

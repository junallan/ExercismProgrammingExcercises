module BookingUpForBeauty

// The following line is needed to use the DateTime type
open System

let schedule (appointmentDateDescription: string): DateTime = DateTime.Parse appointmentDateDescription

let hasPassed (appointmentDate: DateTime): bool = appointmentDate.CompareTo DateTime.Now < 0

let isAfternoonAppointment (appointmentDate: DateTime): bool = 12 <= appointmentDate.Hour && appointmentDate.Hour < 18

let description (appointmentDate: DateTime): string = $"""You have an appointment on {appointmentDate.ToString("M/d/yyyy h:mm:ss tt")}.""";

let anniversaryDate(): DateTime = failwith "Please implement the 'anniversaryDate' function"

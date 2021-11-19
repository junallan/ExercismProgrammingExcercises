using System;

public enum LogLevel
{ 
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42,
    Unknown = 0
}

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine) => logLine.Split(":")[0] switch
    {
        string command when command.EndsWith("[TRC]") => LogLevel.Trace,
        string command when command.EndsWith("[DBG]") => LogLevel.Debug,
        string command when command.EndsWith("[INF]") => LogLevel.Info,
        string command when command.EndsWith("[WRN]") => LogLevel.Warning,
        string command when command.EndsWith("[ERR]") => LogLevel.Error,
        string command when command.EndsWith("[FTL]") => LogLevel.Fatal,
        _ => LogLevel.Unknown
    };

    public static string OutputForShortLog(LogLevel logLevel, string message) => $"{(int)logLevel}:{message}";
}

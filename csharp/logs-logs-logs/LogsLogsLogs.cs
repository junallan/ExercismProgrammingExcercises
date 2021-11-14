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
    public static LogLevel ParseLogLevel(string logLine) => logLine.TrimStart() switch
    {
        string lineInfo when lineInfo.StartsWith("[TRC]") => LogLevel.Trace,
        string lineInfo when lineInfo.StartsWith("[DBG]") => LogLevel.Debug,
        string lineInfo when lineInfo.StartsWith("[INF]") => LogLevel.Info,
        string lineInfo when lineInfo.StartsWith("[WRN]") => LogLevel.Warning,
        string lineInfo when lineInfo.StartsWith("[ERR]") => LogLevel.Error,
        string lineInfo when lineInfo.StartsWith("[FTL]") => LogLevel.Fatal,
        _ => LogLevel.Unknown
    };

    public static string OutputForShortLog(LogLevel logLevel, string message) => $"{(int)logLevel}:{message}";
}

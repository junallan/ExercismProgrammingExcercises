using System;

public enum LogLevel
{ 
    Trace,
    Debug,
    Info,
    Warning,
    Error,
    Fatal,
    Unknown
}

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine) => logLine.TrimStart() switch
    {
        string lineInfo when lineInfo.StartsWith("[TRC]") => LogLevel.Trace,
        string lineInfo when lineInfo.StartsWith("[DBG]") => LogLevel.Debug,
        string lineInfo when lineInfo.StartsWith("[WRN]") => LogLevel.Warning,
        string lineInfo when lineInfo.StartsWith("[ERR]") => LogLevel.Error,
        string lineInfo when lineInfo.StartsWith("[FTL]") => LogLevel.Fatal,
        _ => LogLevel.Unknown
    };

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        throw new NotImplementedException("Please implement the (static) LogLine.OutputForShortLog() method");
    }
}

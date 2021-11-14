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
        string lineInfo when lineInfo.StartsWith("[WRN]") => LogLevel.Warning,
        _ => LogLevel.Unknown
    };

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        throw new NotImplementedException("Please implement the (static) LogLine.OutputForShortLog() method");
    }
}

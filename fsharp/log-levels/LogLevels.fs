module LogLevels

let message (logLine: string) = logLine.Split(':').[1].Trim()

let logLevel(logLine: string) = logLine.Split(':').[0].Replace("[","").Replace("]","").Trim().ToLower()

let reformat(logLine: string) = message logLine + " (" + logLevel logLine + ")" 

module LogLevels

let message (logLine: string): string = (logLine.Split ':'[1]).Trim()

let logLevel(logLine: string): string = (logLine.Split ':'[0]).Replace("[","").Replace("]","").Trim().ToLower()

let reformat(logLine: string): string = failwith "Please implement the 'reformat' function"

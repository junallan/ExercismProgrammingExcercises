module LogLevels

let message (logLine: string): string = (logLine.Split ':'[1]).Trim()

let logLevel(logLine: string): string = failwith "Please implement the 'logLevel' function"

let reformat(logLine: string): string = failwith "Please implement the 'reformat' function"

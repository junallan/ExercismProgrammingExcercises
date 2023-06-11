
(ns log-levels (:require [clojure.string :refer (lower-case trim)]))

(defn- parse [line part]
  (let [mitch (re-matcher #"\[(?<lvl>[A-Z]+)\]:\s+(?<msg>.+)\s*" line)]
    (when (.matches mitch)
      (.group mitch part))))

(defn message
  "Takes a string representing a log line
   and returns its message with whitespace trimmed."
  [s]
  (trim (parse s "msg")))

(defn log-level
  "Takes a string representing a log line
   and returns its level in lower-case."
  [s]
  (lower-case (parse s "lvl")))

(defn reformat
  "Takes a string representing a log line and formats it
   with the message first and the log level in parentheses."
  [s]
  (str (message s) " (" (log-level s) ")")
  )
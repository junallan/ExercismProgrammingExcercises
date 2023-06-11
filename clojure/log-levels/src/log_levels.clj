(ns log-levels
  (:require [clojure.string :as str]))

(defn string-starts-with? [s prefix]
  (str/starts-with? s prefix))

(defn contains-log-level-line? [s]
  (and (string-starts-with? s "[INFO]:") (string-starts-with? s "[WARNING]:") (string-starts-with? s "[ERROR]:"))
)

(defn message
  "Takes a string representing a log line
   and returns its message with whitespace trimmed."
  [s]
  (let [split-result (str/split s #":")]
    (str/trim (nth split-result 1))))

(defn log-level
  "Takes a string representing a log line
   and returns its level in lower-case."
  [s]
  )

(defn reformat
  "Takes a string representing a log line and formats it
   with the message first and the log level in parentheses."
  [s]
  )

(ns log-levels
  (:require [clojure.string :as str]))

(defn string-starts-with? [s prefix]
  (str/starts-with? s prefix))

(defn contains-log-level-line? [s]
  (and (string-starts-with? s "[INFO]:") (string-starts-with? s "[WARNING]:") (string-starts-with? s "[ERROR]:"))
)

(defn remove-start-end-chars [s]
  (subs s 1 (dec (count s))))

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
  (let [pattern #"^\[(INFO|WARNING|ERROR)]"
        matcher (re-matcher pattern s)]
    (if (.find matcher)
      (str/lower-case (remove-start-end-chars (.group matcher)))
      nil)))

(defn reformat
  "Takes a string representing a log line and formats it
   with the message first and the log level in parentheses."
  [s]
  (str (message s) " (" (log-level s) ")")
  )
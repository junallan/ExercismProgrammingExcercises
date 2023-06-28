(ns squeaky-clean
  (:require [clojure.string :as str]))

(defn kebab-to-camel
  "Converts a kebab-case string to camelCase."
  [s]
  (->> (clojure.string/split s #"-")
       (map-indexed (fn [i part]
                      (if (zero? i)
                        part
                        (clojure.string/capitalize part))))
       (apply str)))

(defn clean
  "Replaces spaces with underscores and control characters with 'CTRL' in the input string."
  [s]
  (-> s
      (str/replace #"\p{Cc}" "CTRL")
      (str/replace #"\d" "")
      (str/replace #"[α-ω]" "")
      (kebab-to-camel)
      (str/replace " " "_")))

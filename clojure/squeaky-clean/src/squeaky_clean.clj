(ns squeaky-clean
  (:require [clojure.string :as str]))

(defn capitalize-first-letter [input]
  (str (str/upper-case (first input))
       (subs input 1)))

(defn kebab-to-camel
  "Converts a kebab-case string to camelCase."
  [s]
  (->> (clojure.string/split s #"-")
       (map-indexed (fn [i part]
                      (if (zero? i)
                        part
                        (capitalize-first-letter part))))
       (apply str)))

(defn clean
  "Replaces spaces with underscores and control characters with 'CTRL' in the input string."
  [s]
  (-> s
      (kebab-to-camel)
      (str/replace #"\p{Cc}" "CTRL")
      (str/replace #"\p{InEmoticons}" "")
      (str/replace #"\d" "")
      (str/replace #"[α-ω]" "")
      (kebab-to-camel)
      (str/replace " " "_")))

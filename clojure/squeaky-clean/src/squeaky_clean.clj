(ns squeaky-clean
  (:require [clojure.string :as str]))

(defn clean
  "Replaces spaces with underscores and control characters with 'CTRL' in the input string."
  [s]
  (-> s
      (str/replace #"\p{Cc}" "CTRL")
      (str/replace " " "_")))

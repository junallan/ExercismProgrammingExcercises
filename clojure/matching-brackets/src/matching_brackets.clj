(ns matching-brackets)

(require '[clojure.string :as str])

(defn eliminate-whitespace [string]
  (str/replace string #"\s" ""))

(defn validate-brackets [string, stack]
  (if (empty? string)
    (if (empty? stack)
      true
      false)
    (let [
          [first-char & rest] string
          [top & bottom] stack]
      (cond
        (and (= first-char \}) (= top \{)) (validate-brackets rest bottom)
        (and (= first-char \]) (= top \[)) (validate-brackets rest bottom)
        (and (= first-char \)) (= top \()) (validate-brackets rest bottom)
        :else (validate-brackets rest (cons first-char stack))
        ))))

(defn valid? [string]
  (validate-brackets (eliminate-whitespace string) [])
)







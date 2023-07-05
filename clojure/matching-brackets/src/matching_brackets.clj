(ns matching-brackets)

(defn validate-brackets [string stack]
  (if (empty? string)
    (if (empty? stack)
      true
      false)
    (let [[first-char & rest] string
          [top & bottom] stack]
      (cond
        (and (= first-char \}) (= top \{)) (validate-brackets rest bottom)
        (and (= first-char \]) (= top \[)) (validate-brackets rest bottom)
        (and (= first-char \)) (= top \()) (validate-brackets rest bottom)
        (#{\{ \[ \( \} \] \)} first-char) (validate-brackets rest (cons first-char stack))
        :else (validate-brackets rest stack)))))
        
(defn valid? [string]
  (validate-brackets string []))









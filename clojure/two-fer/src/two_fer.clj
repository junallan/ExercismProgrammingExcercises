(ns two-fer)

(defn two-fer [& [name]]
  (let [friend-name (if (nil? name) "you" name)]
   (str "One for " friend-name ", one for me.")))

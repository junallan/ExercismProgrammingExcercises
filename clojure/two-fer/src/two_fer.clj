(ns two-fer)

(defn two-fer [& [name]]
  (let [name (if (nil? name) "you" name)]
   (str "One for " name ", one for me.")))

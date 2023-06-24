(ns robot-name)

(defn concatenate-strings [& strings]
  (apply str strings))

(defn random-letter []
  (let [letters "ABCDEFGHIJKLMNOPQRSTUVWXYZ"]
    (rand-nth letters)))

(defn make-name []
  (concatenate-strings 
    (random-letter) 
    (random-letter) 
    (format "%03d" (rand-int 1000))))

(defn robot [] 
  (atom (make-name)))

(defn robot-name [bot] 
  @bot)

(defn reset-name [bot] 
  (reset! bot (make-name))
)

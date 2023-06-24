(ns robot-name)

(defn concatenate-strings [& strings]
  (apply str strings))

(defn random-letter []
  (let [letters "ABCDEFGHIJKLMNOPQRSTUVWXYZ"]
    (rand-nth letters)))

(defn random-number []
  (let [numbers ["0" "1" "2" "3" "4" "5" "6" "7" "8" "9"]]
    (rand-nth numbers)))    

(defn make-name []
  (concatenate-strings (random-letter) (random-letter) (random-number) (random-number) (random-number)))

(defn robot [] 
  (atom (make-name)))

(defn robot-name [bot] 
  @bot)

(defn reset-name [bot] 
  (reset! bot (make-name))
)

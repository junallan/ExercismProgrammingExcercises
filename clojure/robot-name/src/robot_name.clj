(ns robot-name)

(defn concatenate-strings [& strings]
  (apply str strings))

(defn random-letter []
  (let [letters ["A" "B" "C" "D" "E" "F" "G" "H" "I" "J" "K" "L" "M" 
    "N" "O" "P" "Q" "R" "S" "T" "U" "V" "W" "X" "Y" "Z"]]
    (rand-nth letters)))

(defn random-number []
  (let [numbers ["0" "1" "2" "3" "4" "5" "6" "7" "8" "9"]]
    (rand-nth numbers)))    

(defn robot [] ;; <- arglist goes here
  ;; your code goes here
)

(defn robot-name [robot] ;; <- arglist goes here
      (concatenate-strings random-letter random-letter random-number random-number random-number))

(defn reset-name [robot] ;; <- arglist goes here
  ;; your code goes here
)


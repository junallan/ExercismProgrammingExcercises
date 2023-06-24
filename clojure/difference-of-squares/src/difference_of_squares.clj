(ns difference-of-squares)

(defn square [num]
  (* num num))

(defn difference [] ;; <- arglist goes here
  ;; your code goes here
)

(defn sum-of-squares [] ;; <- arglist goes here
  ;; your code goes here
)

(defn square-of-sum [num]
  (let [sum (reduce + (range 1 (inc num)))]
  (square sum)))

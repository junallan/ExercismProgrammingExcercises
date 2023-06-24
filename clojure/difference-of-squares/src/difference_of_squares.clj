(ns difference-of-squares)

(defn square [num]
  (* num num))

(defn difference [] ;; <- arglist goes here
  ;; your code goes here
)

(defn sum-of-squares [num] 
  (loop [n num
         acc 0]
    (if (<= n 0)
      acc
      (recur (dec n) (+ acc (* n n))))))

;; (defn sum-of-squares [num] 
;;   (if (<= num 0)
;;     0
;;     (+ (square num) (sum-of-squares (dec num)))))

(defn square-of-sum [num]
  (let [sum (reduce + (range 1 (inc num)))]
  (square sum)))

(ns difference-of-squares)

(defn square [num]
  (* num num))

(defn sum-of-squares [num] 
  (/ (* num (inc num) (inc (* 2 num))) 6))

  ;; (->> (range 1 (inc num))
  ;;   (map #(* % %))
  ;;   (reduce +)))

  ;; (loop [n num
  ;;        acc 0]
  ;;   (if (<= n 0)
  ;;     acc
  ;;     (recur (dec n) (+ acc (* n n))))))

;; (defn sum-of-squares [num] 
;;   (if (<= num 0)
;;     0
;;     (+ (square num) (sum-of-squares (dec num)))))

(defn square-of-sum [num]
  (let [sum (reduce + (range 1 (inc num)))]
  (square sum)))

(defn difference [num]
  (- (square-of-sum num) (sum-of-squares num)))


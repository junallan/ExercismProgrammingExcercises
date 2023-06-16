(ns bird-watcher)

(def last-week 
  [0 2 5 3 7 8 4])

(defn today [birds]
  (if (empty? birds)
    nil
    (get birds (dec (count birds)))))
  
(defn inc-bird [birds]
  (let [last-bird (today birds)]
   (if last-bird
     (assoc birds (dec (count birds)) (inc last-bird))
     birds)))

(defn day-without-birds? [birds]
  (some #(= % 0) birds))

(defn n-days-count [birds n]
  (reduce + (subvec birds 0 n)))

(defn busy-days [birds]
  )

(defn odd-week? [birds]
  )

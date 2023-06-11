(ns cars-assemble)

(def CARS_PRODUCED_PER_HOUR 221.0)
(def MINUTES_PER_HOUR 60)

(defn round-to-decimal-places
  [num places]
  (let [scale (Math/pow 10 places)]
    (/ (Math/round (* num scale)) scale)))

(defn production-rate
  "Returns the assembly line's production rate per hour,
   taking into account its success rate"
  [speed]
  (let [rate (* speed
              (* CARS_PRODUCED_PER_HOUR
               (cond (> speed 9) 0.77
                     (> speed 8) 0.8
                     (> speed 4) 0.9
                     (> speed 0) 1
                     :else 0)))]
    (round-to-decimal-places rate 1)))

(defn working-items
  "Calculates how many working cars are produced per minute"
  [speed]
  (int (/ (production-rate speed) MINUTES_PER_HOUR)))

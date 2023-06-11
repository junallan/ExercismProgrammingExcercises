(ns cars-assemble)

(def ^:private cars-produced-per-hour 221.0)
(def ^:private minutes-per-hour 60)

(defn round-to-decimal-places
  [num places]
  (let [scale (Math/pow 10 places)]
    (/ (Math/round (* num scale)) scale)))

(defn success-percentage
  [speed]
  (cond 
    (> speed 9) 0.77
    (> speed 8) 0.8
    (> speed 4) 0.9
    (> speed 0) 1
    :else 0)
)

(defn success-rate
  [speed]
  (* cars-produced-per-hour (success-percentage speed)))

(defn production-rate
  "Returns the assembly line's production rate per hour,
   taking into account its success rate"
  [speed]
  (let [rate 
     (* speed (success-rate speed))]
   (round-to-decimal-places rate 1)))

(defn working-items
  "Calculates how many working cars are produced per minute"
  [speed]
  (int (/ (production-rate speed) minutes-per-hour)))
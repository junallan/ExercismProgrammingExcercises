(ns cars-assemble)

(def CARS_PRODUCED_PER_HOUR 221.0)
(def MINUTES_PER_HOUR 60)

(defn production-rate
  "Returns the assembly line's production rate per hour,
   taking into account its success rate"
  [speed]
  (cond (> speed 9) (* (* 0.77 CARS_PRODUCED_PER_HOUR) speed)
        (> speed 8) (* (* 0.8 CARS_PRODUCED_PER_HOUR) speed)
        (> speed 4) (* (* 0.9 CARS_PRODUCED_PER_HOUR) speed)
        (> speed 0) (* CARS_PRODUCED_PER_HOUR speed)
        :else 0.0) 
  )

(defn working-items
  "Calculates how many working cars are produced per minute"
  [speed]
  (int (/ (production-rate speed) MINUTES_PER_HOUR)))

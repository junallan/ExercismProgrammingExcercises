(ns leap)


(defn is-divisible-by? [year number]
  (zero? (mod year number)))

(defn leap-year? [year] 
  (or (and (is-divisible-by? year 4)
           (not (is-divisible-by? year 100)))
      (is-divisible-by? year 400)))

  ;; (if (zero? (mod year 4))
  ;;   (if (zero? (mod year 100)) 
  ;;     (if (zero? (mod year 400))
  ;;       true
  ;;       false)
  ;;     true)
  ;;   false))  

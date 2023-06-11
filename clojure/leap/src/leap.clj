(ns leap)

(defn leap-year? [year] 
  (or (and (zero? (mod year 4))
           (not (zero? (mod year 100))))
      (zero? (mod year 400))))

  ;; (if (zero? (mod year 4))
  ;;   (if (zero? (mod year 100)) 
  ;;     (if (zero? (mod year 400))
  ;;       true
  ;;       false)
  ;;     true)
  ;;   false))  

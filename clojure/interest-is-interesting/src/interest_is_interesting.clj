(ns interest-is-interesting)

(defn interest-rate
  [balance]
  (cond
    (< balance 0) -0.3213
    (< balance 1000) 0.5
    (< balance 5000) 1.621
    :else 2.475))

(defn annual-balance-update
  "TODO: add docstring"
  [balance]
  )

(defn amount-to-donate
  "TODO: add docstring"
  [balance tax-free-percentage]
  )
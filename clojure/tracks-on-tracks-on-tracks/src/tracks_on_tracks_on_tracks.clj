(ns tracks-on-tracks-on-tracks)

(defn new-list
  "Creates an empty list of languages to practice."
  []
  ())

(defn add-language
  "Adds a language to the list."
  [lang-list lang]
  (cons lang lang-list))

(defn first-language
  "Returns the first language on the list."
  [lang-list]
  (first lang-list))

(defn remove-language
  "Removes the first language added to the list."
  [lang-list]
  (next lang-list))

(defn count-languages
  "Returns the total number of languages on the list."
  [lang-list]
  (count lang-list))

(defn learning-list
  "Creates an empty list, adds Clojure and Lisp, removes Lisp, adds
  Java and JavaScript, then finally returns a count of the total number
  of languages."
  []
  (let [emptyList (new-list)
        clojureList (add-language emptyList "Clojure")
        clojureAndLispList (add-language clojureList "Lisp")
        clojureRemovedList (remove-language clojureAndLispList)
        javaAndClojureList (add-language clojureRemovedList "Java")
        javaScriptJavaAndClojureList (add-language javaAndClojureList "JavaScript")]
   (count-languages javaScriptJavaAndClojureList)))

export class Palindromes {
   static generate(factor) {
        if (factor.minFactor > factor.maxFactor) {
            throw Error('min must be <= max');
        }

       let smallestProduct = { value: null, factors: [] };
       let largestProduct = { value: null, factors: [] };

       for (let i = factor.minFactor; i <= factor.maxFactor; i++) {
           for (let j = i; j <= factor.maxFactor; j++) {
               let currentProductEvaluation = i * j;
            
               if (this.isPalindrome(currentProductEvaluation.toString())) {
                   if (smallestProduct.value === null || (smallestProduct.value > currentProductEvaluation)) {
                       smallestProduct = { value: currentProductEvaluation, factors: [[i,j]] };
                   }
                   else if (smallestProduct.value === currentProductEvaluation) {
                       smallestProduct.factors.push([i, j]);
                   }

                   if (largestProduct.value === null || (largestProduct.value < currentProductEvaluation)) {
                       largestProduct = { value: currentProductEvaluation, factors: [[i, j]] };
                   }
                   else if (largestProduct.value === currentProductEvaluation) {
                       largestProduct.factors.push([i, j]);
                   }
               }
           }
       }

       return { smallest: smallestProduct, largest: largestProduct };
   }

    static isPalindrome(data) {
        return (data === data.split("").reverse().join(""));
    }
}

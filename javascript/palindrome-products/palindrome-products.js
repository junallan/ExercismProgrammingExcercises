export class Palindromes {
    static generate(factor) {
        if (factor.minFactor > factor.maxFactor) {
            throw Error('min must be <= max');
        }

      let productList = [];

      for (let i = factor.minFactor; i <= factor.maxFactor; i++) {
          for (let j = i; j <= factor.maxFactor; j++) {         
              let result = (i * j).toString();
             
              if (result === result.split("").reverse().join("")) {
                  productList.push({ value: i*j, factor: [i, j]});
              }
          }
      }

      let palindromesSorted = productList.sort((a, b) => a.value - b.value);
      let palindromes = [];

      if (palindromesSorted.length === 0) {
          palindromes = { smallest: { value: null, factors: [] }, largest: { value: null, factors: [] } };

          return palindromes;
      }

      let currentProductValue = palindromesSorted[0].value;
      let currentFactors = [];

      for (let i = 0; i < palindromesSorted.length; i++) {
          if (palindromesSorted[i].value === currentProductValue) {
              currentFactors.push(palindromesSorted[i].factor);

              if (i === (palindromesSorted.length - 1)) {
                  palindromes.push({ value: currentProductValue, factors: currentFactors });
              }
          }
          else {
              palindromes.push({ value: currentProductValue, factors: currentFactors });

              if (i === (palindromesSorted.length - 1)) {
                  palindromes.push({ value: palindromesSorted[i].value, factors: [palindromesSorted[i].factor]});
              }
              else {
                  currentProductValue = palindromesSorted[i].value;
                  currentFactors = [];
                  currentFactors.push(palindromesSorted[i].factor);
              }
          }
      }

      palindromes = { smallest: palindromes[0], largest: palindromes[palindromes.length - 1] };

      return palindromes;
  }
}

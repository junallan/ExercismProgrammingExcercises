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
                  // console.log("(i,j): " + i + "," + j);
                  productList.push({ value: i*j, factor: [i, j]});
              }
          }
      }

      let palindromesSorted = productList.sort((a, b) => a.value - b.value);
      let palindromes = [];

      let currentProductValue = palindromesSorted[0].value;
      let currentFactors = [];

      for (let i = 0; i < palindromesSorted.length; i++) {
          //console.log(palindromesSorted[i]);
          if (palindromesSorted[i].value === currentProductValue) {
              currentFactors.push(palindromesSorted[i].factor);

              if (i === (palindromesSorted.length - 1)) {
                  //console.log(palindromesSorted[i].value);
                  //console.log(palindromesSorted[i].factor);
                  palindromes.push({ value: currentProductValue, factors: currentFactors });
              }
          }
          else {
              palindromes.push({ value: currentProductValue, factors: currentFactors });
              //console.log(i);
              //console.log(palindromesSorted.length);
              if (i === (palindromesSorted.length - 1)) {
                  //console.log(palindromesSorted[i].value);
                  //console.log(palindromesSorted[i].factor);
                  palindromes.push({ value: palindromesSorted[i].value, factors: [palindromesSorted[i].factor]});
              }
              else {
                  currentProductValue = palindromesSorted[i].value;
                  currentFactors = [];
                  currentFactors.push(palindromesSorted[i].factor);
              }
          }
      }
    // console.log(palindromes[7]);
      if (palindromes !== []) {
          palindromes.smallest = palindromes[0];
          palindromes.largest = palindromes[palindromes.length - 1];
      }
      else {
          palindromes.push({ smallest: { value: null, factors: [] }, largest: { value: null, factors: [] } });

          //palindromes.smallest = { value: null, factors: [] };
          //palindromes.largest = { value: null, factors: [] };
      }
    

      return palindromes;
  }
}

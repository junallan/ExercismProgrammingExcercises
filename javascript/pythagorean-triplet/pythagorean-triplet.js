export function triplets({ minFactor, maxFactor, sum }) {
    let allTriplets = [];
    let minFirstNumber = minFactor - 1 || 0;
    let maxThirdNumber = maxFactor || sum - 1;
    let sumLimit = sum;

    for (let i = minFirstNumber; i < sumLimit; i++) {
        for (let j = i+1; j < sumLimit; j++) {
            let firstNumber = i + 1;
            let secondNumber = j + 1;

            if (firstNumber + secondNumber + (secondNumber + 1) <= sumLimit) {
                let aSquared = firstNumber ** 2;
                let bSquared = secondNumber ** 2;

                let cSquareRoot = Math.sqrt(aSquared + bSquared);

                if (cSquareRoot > maxThirdNumber) { continue;};

                if ((cSquareRoot % 1 === 0) && (firstNumber + secondNumber + cSquareRoot === sumLimit)) {
                    allTriplets.push(new Triplet(firstNumber, secondNumber, cSquareRoot));
                }
            }
        }
    }

    return allTriplets;
}

class Triplet {
  constructor(a, b, c) {
      this._a = a;
      this._b = b;
      this._c = c;
  }
    
  toArray() {
      return [this._a, this._b, this._c];
  }
}

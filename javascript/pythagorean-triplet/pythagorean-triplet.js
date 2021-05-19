export function triplets({ minFactor, maxFactor, sum }) {
    let allTriplets = [];
    //allTriplets.push(new Triplet(1, 2, 3));
    //return allTriplets;
    let sumLimit = sum;

    for (let i = 0; i < sumLimit; i++) {
        let firstNumber = i + 1;
        let secondNumber = i + 2;
        let thirdNumbr = i + 3;

        if (firstNumber + secondNumber + thirdNumbr <= sumLimit) {
            let aSquared = firstNumber ** 2;
            let bSquared = secondNumber ** 2;

            let cSquareRoot = Math.sqrt(aSquared + bSquared);
            if (cSquareRoot % 1 === 0) {
                allTriplets.push(new Triplet(firstNumber, secondNumber, cSquareRoot));
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

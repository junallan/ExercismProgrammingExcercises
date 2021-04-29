export class Squares {
  constructor(number) {
      this._number = number;
  }

  get sumOfSquares() {
      return [...Array(this._number).keys()].reduce((accumulator, currentValue) => { return accumulator + (currentValue + 1) ** 2 }, 0);
  }

  get squareOfSum() {
      return [...Array(this._number).keys()].reduce((accumulator, currentValue) => { return accumulator + (currentValue + 1)}, 0) ** 2;
  }

  get difference() {
      return this.squareOfSum - this.sumOfSquares;
  }
}

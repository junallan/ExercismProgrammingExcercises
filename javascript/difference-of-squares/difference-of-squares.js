export class Squares {
  constructor(number) {
      this._number = number;
  }

  get sumOfSquares() {
        return (this._number * (this._number + 1) * (2 * this._number + 1)) / 6;
  }

  get squareOfSum() {
      return [...Array(this._number).keys()].reduce((accumulator, currentValue) => { return accumulator + (currentValue + 1)}, 0) ** 2;
  }

  get difference() {
      return this.squareOfSum - this.sumOfSquares;
  }
}

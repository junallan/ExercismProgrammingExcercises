export class ComplexNumber {
  constructor(realNumber, imaginaryNumber) {
      this._realNumber = realNumber;
      this._imaginaryNumber = imaginaryNumber;
  }

  get real() {
      return this._realNumber;
  }

  get imag() {
      return this._imaginaryNumber;
  }

  get abs() {
      return Math.sqrt(this._realNumber ** 2 + this._imaginaryNumber ** 2);
  }

  add(complexNumber) {
      return new ComplexNumber(this._realNumber + complexNumber.real, this._imaginaryNumber + complexNumber.imag);
  }

  sub(complexNumber) {
      return new ComplexNumber(this._realNumber - complexNumber.real, this._imaginaryNumber - complexNumber.imag);
  }

    div(complexNumber) {
        let denominator = (complexNumber.real ** 2 + complexNumber.imag ** 2);

        return new ComplexNumber((this._realNumber * complexNumber.real + this._imaginaryNumber * complexNumber.imag) / denominator,
            (this._imaginaryNumber * complexNumber.real - this._realNumber * complexNumber.imag) / denominator);
     
  }

  mul(complexNumber) {
      return new ComplexNumber(this._realNumber * complexNumber.real - this._imaginaryNumber * complexNumber.imag,
          this._imaginaryNumber * complexNumber.real + this._realNumber * complexNumber.imag);
  }

  get conj() {
      return new ComplexNumber(this._realNumber, this._imaginaryNumber === 0 ? 0 : -1 * this._imaginaryNumber);
  }

  get exp() {
      let factor = Math.exp(this._realNumber);

      return new ComplexNumber(factor * Math.cos(this._imaginaryNumber), factor * Math.sin(this._imaginaryNumber));
  }
}

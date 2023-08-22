export class Triangle {
  private sides: number[];

  constructor(...sides: number[]) {
    this.sides = sides;
  }

  get isEquilateral() {
    return this.sides.length === 3 
      && this.sides[0] !== 0
      && this.sides.every(s => s == this.sides[0]);
  }

  get isIsosceles() {
    throw new Error('Remove this statement and implement this function')
  }

  get isScalene() {
    throw new Error('Remove this statement and implement this function')
  }
}

export class Triangle {
  private _sides: number[];

  constructor(...sides: number[]) {
    this._sides = sides;
  }

  get isEquilateral() {
    throw new Error('Remove this statement and implement this function')
  }

  get isIsosceles() {
    throw new Error('Remove this statement and implement this function')
  }

  get isScalene() {
    throw new Error('Remove this statement and implement this function')
  }
}

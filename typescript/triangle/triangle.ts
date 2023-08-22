export class Triangle {
  private sides: number[];

  constructor(...sides: number[]) {
    this.sides = sides;
  }

  get isEquilateral() : boolean {
    const [a, b, c] = this.sides;
    return a !== 0 && a === b && b === c;
  }

  get isIsosceles() : boolean {
    if (this.sides.length !== 3 || this.sides.includes(0)) return false;
    return isTriangle(this.sides[0], this.sides[1], this.sides[2]) 
      && (this.sides[0] === this.sides[1] 
        || this.sides[1] === this.sides[2] 
        || this.sides[0] === this.sides[2]);
  }

  get isScalene() : boolean {
    if (this.sides.length !== 3 || this.sides.includes(0)) return false;
    return isTriangle(this.sides[0], this.sides[1], this.sides[2]) 
      && !this.isEquilateral && !this.isIsosceles;
  }
}

function isTriangle(a: number, b: number, c: number) :boolean {
  return ((a + b) >= c)
    && ((b + c) >= a)
    && ((a + c) >= b);
}
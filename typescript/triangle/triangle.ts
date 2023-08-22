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
    if (this.sides.length !== 3 || this,this.sides.includes(0)) return false;
    if (this.isEquilateral) return true;

    if(!isTriangle(this.sides[0], this.sides[1], this.sides[2])) return false;

    return this.sides[0] === this.sides[1] 
      || this.sides[0] === this.sides[2]
      || this.sides[1] === this.sides[2];
  }

  get isScalene() {
    if (this.sides.length !== 3 || this,this.sides.includes(0)) return false;
    if (this.isEquilateral || this.isIsosceles) return false;
    return isTriangle(this.sides[0], this.sides[1], this.sides[2]);
  }
}

function isTriangle(a: number, b: number, c: number) :boolean {
  return ((a + b) >= c)
    && ((b + c) >= a)
    && ((a + c) >= b);
}




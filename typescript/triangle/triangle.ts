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

    const elementCounts = getElementCounts(this.sides);

    if (elementCounts.size !== 2) return false;

    const [firstLengthCount, secondLengthCount] = elementCounts.values();
    const [firstLengthKey, secondLengthKey] = elementCounts.keys();

    return (
      (firstLengthCount === 2 && (firstLengthKey + firstLengthKey) > secondLengthKey) ||
      (secondLengthCount === 2 && (secondLengthKey + secondLengthKey) > firstLengthKey)
    );
  }

  get isScalene() {
    throw new Error('Remove this statement and implement this function')
  }
}

function getElementCounts(array: number[]) : Map<number, number> {
  return array.reduce((counts, item) => {
    counts.set(item, (counts.get(item) || 0) + 1);
    return counts;
  }, new Map<number, number>());
}


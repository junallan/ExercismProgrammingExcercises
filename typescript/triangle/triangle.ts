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
    if (this.sides.length !== 3) return false;
    if (this,this.sides.includes(0)) return false;
    if (this.isEquilateral) return true;

    const elementCounts = getElementCounts(this.sides);
    if (elementCounts.size == 3) return false;

    const keysIterator = elementCounts.keys();

    const firstLengthKey = keysIterator.next().value;
    const firstLengthCount = elementCounts.get(firstLengthKey);
    const secondLengthKey = keysIterator.next().value;
    const secondLengthCount = elementCounts.get(secondLengthKey);

    if (firstLengthCount == 2 && secondLengthCount == 1) { 
      return ((firstLengthKey + firstLengthKey) > secondLengthKey) 
        && ((firstLengthKey + secondLengthKey) > firstLengthKey);
    }

    if (firstLengthCount == 1 && secondLengthCount == 2) { 
      return ((secondLengthKey + secondLengthKey) > firstLengthKey)
        && ((firstLengthKey + secondLengthKey) > secondLengthKey);
    }

    return false;
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


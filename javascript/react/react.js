export class InputCell {
  constructor(value) {
      this.value = value;
  }

  setValue(value) {
      this.value = value;
  }
}

export class ComputeCell {
  constructor(inputCells, fn) {
      this.inputCells = inputCells;
      this.fn = fn;
  }

  get value() {
      return this.fn(this.inputCells);
  }

  addCallback(cb) {
      this.cb = cb;
      //console.log('inputCells: ' + this.inputCells.value);
      //console.log('fn: ' + this.fn);
      cb.setComputedCell(this.inputCells);
      cb.setComputedCellfn(this.fn);
  }

  removeCallback(cb) {
    throw new Error('Remove this statement and implement this function');
  }
}

export class CallbackCell {
  constructor(fn) {
      this.fn = fn;
  }

  setComputedCell(cell) {
      this.computedCell = cell;
     
  }

  setComputedCellfn(fn) {
      this.computedCellfn = fn;
  }

    get values() {
        console.log('computedCell: ' + this.computedCell[0].value);
        console.log('computedCellfn: ' + this.computedCellfn);
        console.log('fn: ' + this.fn);

        return [this.fn(new ComputeCell(this.computedCell, this.computedCellfn))];
        //return this.fn(this.computedCellfn(this.computedCell));
        //return this.fn(this.computedCellfn(computedCell));
  }
}

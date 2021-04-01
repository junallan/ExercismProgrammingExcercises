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
      this.value = fn(inputCells);
  }

  addCallback(cb) {
      this.cb = cb;
  }

  removeCallback(cb) {
    throw new Error('Remove this statement and implement this function');
  }
}

export class CallbackCell {
  constructor(fn) {
      this.fn = fn;
      //this.values = 
  }
}

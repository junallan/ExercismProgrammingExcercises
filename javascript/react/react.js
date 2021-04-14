export class InputCell {
  constructor(value) {
      this.value = value;
      this.values = [];
  }

  setValue(value) {
      this.value = value;
      this.values.push(value);
  }
}

export class ComputeCell {
  constructor(inputCells, fn) {
      this.inputCells = inputCells;
      this.fn = fn;
      this.cb = [];
  }

  get value() {
      return this.fn(this.inputCells);
  }

  addCallback(cb) {
     this.cb.push(cb);
     
     cb.setCurrentComputedValue(this.value);
     cb.setComputedCell(this.inputCells);
     cb.setComputedCellfn(this.fn);
  }

  removeCallback(cb) {
      //this.cb.r(cb);
  }
}

export class CallbackCell {
  constructor(fn) {
      this.fn = fn;
      this.loggedComputedValues = [];
  }

  setCurrentComputedValue(value) {
      this.currentComputedValue = value;
  }

  setComputedCell(cell) {
      this.computedCell = cell;
     
  }

  setComputedCellfn(fn) {
      this.computedCellfn = fn;
  }

    get values() {
        //console.log('this.computedCell[0].values.length:' + this.computedCell[0].values.length);

        for (let i = 0; i < this.computedCell[0].values.length; i++) {
          //console.log('this.computedCell[0].values[i]:' + (this.computedCell[0].values[i]));
            let computedValue = this.computedCellfn([new InputCell(this.computedCell[0].values[i])]);
            let callbackComputedValue = this.fn(new ComputeCell([new InputCell(this.computedCell[0].values[i])], this.computedCellfn));
            //console.log('computedValue:' + computedValue);
           // console.log('callbackComputedValue:' + callbackComputedValue);
            if (computedValue !== this.currentComputedValue) {
                console.log('fn:' + this.fn);
                this.loggedComputedValues.push(callbackComputedValue);
                this.currentComputedValue = computedValue;
            } 
        }

        return this.loggedComputedValues;
  }
}

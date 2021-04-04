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
      this.cb = [];
  }

  get value() {
      return this.fn(this.inputCells);
  }

    addCallback(cb) {
        //if (cb.inputCells.value !== this.cb[this.cb.length - 1]) {

        //}
        //console.log(cb.fn(this.inputCells));
        //console.log(this.inputCells);
        //console.log(this.fn(this.inputCells));
        console.log(this.value);
        //if (this.cb !== [] && this.cb[0].values !== this.fn(new ComputeCell(this.inputCells, this.fn)).values){
            this.cb.push(cb);
            //console.log('inputCells: ' + this.inputCells.value);
            //console.log('fn: ' + this.fn);
            cb.setOriginalComputedValue(this.value);
            cb.setComputedCell(this.inputCells);
            cb.setComputedCellfn(this.fn);
        //}  
  }

  removeCallback(cb) {
    throw new Error('Remove this statement and implement this function');
  }
}

export class CallbackCell {
  constructor(fn) {
      this.fn = fn;
  }

  setOriginalComputedValue(value) {
      this.originalComputedValue = value;
  }

  setComputedCell(cell) {
      this.computedCell = cell;
     
  }

  setComputedCellfn(fn) {
      this.computedCellfn = fn;
  }

    get values() {
        //console.log('computedCell: ' + this.computedCell[0].value);
        //console.log('computedCellfn: ' + this.computedCellfn);
        //console.log('fn: ' + this.fn);

        let computedValue = this.fn(new ComputeCell(this.computedCell, this.computedCellfn));

        if (this.originalComputedValue === computedValue) {
            return [];
        } else {
            return [computedValue];
        }
        
        //return this.fn(this.computedCellfn(this.computedCell));
        //return this.fn(this.computedCellfn(computedCell));
  }
}

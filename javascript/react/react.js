export class InputCell {
  constructor(value) {
      this.value = value;
      this.values.push(value);
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
        //if (cb.inputCells.value !== this.cb[this.cb.length - 1]) {

        //}
        //console.log(cb.fn(this.inputCells));
        //console.log(this.inputCells);
        //console.log(this.fn(this.inputCells));
        //console.log(this.value);
        //if (this.cb !== [] && this.cb[0].values !== this.fn(new ComputeCell(this.inputCells, this.fn)).values){
            this.cb.push(cb);
            //console.log('inputCells: ' + this.inputCells.value);
            //console.log('fn: ' + this.fn);
            cb.setCurrentComputedValue(this.value);
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
        //console.log('computedCell: ' + this.computedCell[0].value);
        //console.log('computedCellfn: ' + this.computedCellfn);
        //console.log('fn: ' + this.fn);

        let computedValue = this.fn(new ComputeCell(this.computedCell, this.computedCellfn));
        console.log('computedValue:' + computedValue);
        if (this.currentComputedValue !== computedValue) {
            this.loggedComputedValues.push(computedValue)
            this.currentComputedValue = computedValue;
           //console.log("1:" + computedValue);
            //return [computedValue];
        } 

       // console.log('loggedComputedValues: ' + this.loggedComputedValues);

        return this.loggedComputedValues;
            //else {
        //    console.log("2:" + this.loggedComputedValues);
        //    this.setOriginalComputedValues(computedValue);
        //    return this.loggedComputedValues;
        //}
        
        //return this.fn(this.computedCellfn(this.computedCell));
        //return this.fn(this.computedCellfn(computedCell));
  }
}

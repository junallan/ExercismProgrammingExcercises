export class InputCell {
  constructor(value) {
      this.value = value;
      this.values = [];
      //this.values.push(value);
  }

  setValue(value) {
      this.value = value;
      //console.log('in setValue: ' + value);
      this.values.push(value);
      //console.log('in setValue values: ' + this.values);
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
        console.log('this.computedCell[0].values.length:' + this.computedCell[0].values.length);

        for (let i = 0; i < this.computedCell[0].values.length; i++) {
           // console.log('this.computedCellfn:' + this.computedCellfn);
          console.log('this.computedCell[0].values[i]:' + (this.computedCell[0].values[i]));
            let computedValue = this.computedCellfn([new InputCell(this.computedCell[0].values[i])]);
            let callbackComputedValue = this.fn(new ComputeCell([new InputCell(this.computedCell[0].values[i])], this.computedCellfn));
            console.log('computedValue:' + computedValue);
            console.log('callbackComputedValue:' + callbackComputedValue);
            //console.log('this.computedCellfn(this.currentComputedValue):' + this.currentComputedValue);
            if (computedValue !== this.currentComputedValue) {
                console.log('fn:' + this.fn);
                this.loggedComputedValues.push(callbackComputedValue);
                this.currentComputedValue = computedValue;
            } 
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

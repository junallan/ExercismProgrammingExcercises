export class Matrix {
    constructor(matrix) {
        this._rows = [];    
        this._columns = [];

        let matrixRow = matrix.split("\n");
    
        this._matrixRowsCount = matrixRow.length;
        this._matrixColumnsCount = matrixRow[0].split(" ").length;

        let elements = matrix.split("\n").join().split(" ").join().split(",").map(Number);

        for (let i = 0; i < this._matrixRowsCount; i++) {
            let rowItems = elements.filter((_, index) => Math.floor(index / this._matrixColumnsCount) === i);
            this._rows.push(rowItems);
        }

        for (let i = 0; i < this._matrixColumnsCount; i++) {
            let columnItems = elements.filter((_, index) => index % this._matrixColumnsCount === i);
            this._columns.push(columnItems);         
        }
  }

  get rows() {
      return this._rows;
  }

  get columns() {
      return this._columns;
  }
}

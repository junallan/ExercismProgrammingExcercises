export class Matrix {
    constructor(matrix) {
        this._rows = [];    
        this._columns = [];

        let matrixRow = matrix.split("\n");
        let matrixRowsCount = matrixRow.length;
        let matrixColumnsCount = matrixRow[0].split(" ").length;

        let elements = matrixRow.join().split(" ").join().split(",").map(Number);

        for (let i = 0; i < matrixRowsCount; i++) {
            let rowItems = elements.filter((_, index) => Math.floor(index / matrixColumnsCount) === i);
            this._rows.push(rowItems);
        }

        for (let i = 0; i < matrixColumnsCount; i++) {
            let columnItems = elements.filter((_, index) => index % matrixColumnsCount === i);
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

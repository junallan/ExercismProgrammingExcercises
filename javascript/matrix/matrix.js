export class Matrix {
    constructor(matrix) {
        let elements = [];
        this._rows = [];    
        this._columns = [];

        let matrixRow = matrix.split("\n");
        this._matrixRowsCount = matrixRow.length;
        this._matrixColumnsCount = matrixRow[0].split(" ").length;

        for (let i = 0; i < this._matrixRowsCount; i++){
            let matrixColumn = matrixRow[i].split(" ");
            let elementRow = [];

            for (let j = 0; j < this._matrixColumnsCount; j++) {
                elements.push(Number(matrixColumn[j]));
            }
        }

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

export class Matrix {
    constructor(matrix) {
        this._rows= [];    
        this._columns = [];
        let matrixRow = matrix.split("\n");
        this._matrixRowsCount = matrixRow.length;
        this._matrixColumnsCount = matrixRow[0].split(" ").length;

        for (let i = 0; i < this._matrixRowsCount; i++){
            let matrixColumn = matrixRow[i].split(" ");
            let elementRow = [];

            for (let j = 0; j < this._matrixColumnsCount; j++) {
                elementRow.push(Number(matrixColumn[j]));
            }

            this._rows.push(elementRow);
        }

        for (let i = 0; i < this._matrixColumnsCount; i++) {
            let elementColumn = [];
            for (let j = 0; j < this._matrixRowsCount; j++) {
                elementColumn.push(this._rows[j][i]);
            }
            this._columns.push(elementColumn);
        }
  }


  get rows() {
      return this._rows;
  }

  get columns() {
      return this._columns;
  }
}

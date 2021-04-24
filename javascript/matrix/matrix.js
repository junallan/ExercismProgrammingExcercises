export class Matrix {
    constructor(matrix) {
        this._matrix = [];
       
        this._columns = [];
        let matrixRow = matrix.split("\n");
        this._matrixRowsCount = matrixRow.length;
        this._matrixColumnsCount = matrixRow[0].split(" ").length;

        for (let i = 0; i < matrixRow.length; i++){
            let matrixColumn = matrixRow[i].split(" ");
            let elementRow = [];
            for (let j = 0; j < matrixColumn.length; j++) {
                elementRow.push(Number(matrixColumn[j]));
            }

            this._matrix.push(elementRow);
        }

        let flattenedMatrix = this._matrix.flat();

        for (let i = 0; i < this._matrixColumnsCount; i++) {
            let elementColumn = [];
            for (let j = 0; j < this._matrixRowsCount; j++) {
                elementColumn.push(this._matrix[j][i]);
            }
            this._columns.push(elementColumn);
        }
  }


  get rows() {
      return this._matrix;
  }

  get columns() {
      return this._columns;
  }
}

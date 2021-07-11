export class Matrix {
    constructor(matrix) {
        this._matrix = matrix.split("\n").map(row => row.split(" ").map(Number));

        //let transpose = (matrixToCopy) => {
        //    let copiedMatrix = [];

        //    for (let i = 0; i < matrixToCopy[0].length; i++) {
        //        copiedMatrix[i] = [];
        //        for (let j = 0; j < matrixToCopy.length; j++) {
        //            copiedMatrix[i][j] = matrixToCopy[j][i];
        //        }
        //    }

        //    return copiedMatrix;
        //}

        //this._transposedMatrix = transpose(this._matrix);
   
        this._transposedMatrix = this._matrix[0].map((_, colIndex) => this._matrix.map(row => row[colIndex]));
  }

  get rows() {
      return this._matrix;
  }

  get columns() {
      return this._transposedMatrix;
    }
}

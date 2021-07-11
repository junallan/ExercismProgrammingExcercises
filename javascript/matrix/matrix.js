export class Matrix {
    constructor(matrix) {
        this._matrix = matrix.split("\n").map(row => row.split(" ").map(Number));

        let transpose = (matrixToTranspose) => {
            return matrixToTranspose[0].map((_, i) => {
                return matrixToTranspose.map((row) => {
                    return row[i];
                });
            });
        };  

        this._transposedMatrix = transpose(this._matrix);
  }

  get rows() {
      return this._matrix;
  }

  get columns() {
      return this._transposedMatrix;
    }
}

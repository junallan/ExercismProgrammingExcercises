import { endianness } from "os";

export class SpiralMatrix {
    static populateEdgesOfMatrix(matrix, startIndex, endIndex, value) {
        if (startIndex === endIndex) {
            matrix[startIndex][endIndex] = value;

            return;
        }

        for (let i = startIndex; i <= endIndex; i++) {
            matrix[startIndex][i] = value++;
        }

        for (let i = startIndex+1; i <= endIndex; i++) {
            matrix[i][endIndex] = value++;
        }

        for (let i = endIndex - 1; i >= 0; i--) {
            matrix[endIndex][i] = value++;
        }

        for (let i = endIndex - 1; i >= 0; i--) {
            matrix[i][startIndex] = value++;
        }

        this.populateEdgesOfMatrix(matrix, startIndex + 1, endIndex - 1, value);
    }

    static ofSize(matrixSize) {
      if (matrixSize === 0) return [];

      let spiralMatrix = [...Array(matrixSize)].map(x => Array(matrixSize));

      this.populateEdgesOfMatrix(spiralMatrix, 0, matrixSize-1, 1);

      return spiralMatrix;
  }
}

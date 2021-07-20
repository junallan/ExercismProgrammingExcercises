export class SpiralMatrix {
  static ofSize(matrixSize) {
      let spiralMatrix = [];

      for (let i = 0; i < matrixSize; i++) {
          let row = []
          for (let j = 0; j < matrixSize; j++) {
              row.push(j+1);
          }
          spiralMatrix.push(row);
      }

      return spiralMatrix;
  }
}

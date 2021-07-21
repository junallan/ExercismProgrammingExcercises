export class SpiralMatrix {
    static populateEdgesOfMatrix(matrix, startIndex, endIndex, value) {
        if (startIndex === endIndex) {
            matrix[startIndex][endIndex] = value;

            return;
        }

        const range = (min, max) => [...Array(max - min + 1).keys()].map(i => i + min);
        
        range(startIndex, endIndex).forEach(i => matrix[startIndex][i] = value++);
        range(startIndex+1, endIndex).forEach(i => matrix[i][endIndex] = value++);
        range(startIndex, endIndex - 1).reverse().forEach(i => matrix[endIndex][i] = value++);
        range(startIndex+1, endIndex - 1).reverse().forEach(i => matrix[i][startIndex] = value++);

        let nextInnerStartIndex = startIndex + 1;
        let nextInnerEndIndex = endIndex - 1;

        if (nextInnerEndIndex < nextInnerStartIndex) return;

        this.populateEdgesOfMatrix(matrix, nextInnerStartIndex, nextInnerEndIndex, value);
    }

    static ofSize(matrixSize) {
      if (matrixSize === 0) return [];

      let spiralMatrix = [...Array(matrixSize)].map(x => Array(matrixSize));

      this.populateEdgesOfMatrix(spiralMatrix, 0, matrixSize-1, 1);

      return spiralMatrix;
  }
}

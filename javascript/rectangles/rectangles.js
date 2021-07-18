export class Rectangles {
    static count(data) {
      //console.log(data.map(row => [...row]))
        let rectangleCount = 0;
        let parsedData = data.map(row => [...row]);

        for (let rowIndex = 1; rowIndex < parsedData.length - 1; rowIndex++) {
            for (let columnIndex = 1; columnIndex < parsedData[0].length - 1; columnIndex++) {
                if (parsedData[rowIndex - 1][columnIndex] === '-' && parsedData[rowIndex + 1][columnIndex] === '-' &&
                    parsedData[rowIndex][columnIndex - 1] === '|' && parsedData[rowIndex][columnIndex + 1] === '|' &&
                    parsedData[rowIndex - 1][columnIndex - 1] === '+' && parsedData[rowIndex - 1][columnIndex + 1] === '+' &&
                    parsedData[rowIndex + 1][columnIndex - 1] === '+' && parsedData[rowIndex + 1][columnIndex + 1] === '+') {
                    rectangleCount++;
                }
            }
        }

      return rectangleCount;
  }
}

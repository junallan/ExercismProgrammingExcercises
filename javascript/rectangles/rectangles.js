export class Rectangles {
    static count(data) {
      //console.log(data.map(row => [...row]))
        let rectangleCoordinates = [];
        let parsedData = data.map(row => [...row]);

        for (let rowIndex = 1; rowIndex < parsedData.length - 1; rowIndex++) {
            for (let columnIndex = 1; columnIndex < parsedData[0].length - 1; columnIndex++) {
                if (parsedData[rowIndex - 1][columnIndex] === '-' && parsedData[rowIndex + 1][columnIndex] === '-' &&
                    parsedData[rowIndex][columnIndex - 1] === '|' && parsedData[rowIndex][columnIndex + 1] === '|' &&
                    parsedData[rowIndex - 1][columnIndex - 1] === '+' && parsedData[rowIndex - 1][columnIndex + 1] === '+' &&
                    parsedData[rowIndex + 1][columnIndex - 1] === '+' && parsedData[rowIndex + 1][columnIndex + 1] === '+') {
                    //console.log(`Row index:${rowIndex}`);
                    //console.log(`Column index:${columnIndex}`);

                    rectangleCoordinates.push({x: rowIndex, y: columnIndex });
                    //console.log(rectangleCoordinates);
                }
            }
        }

        //let adjacentRectangleCoordinatesByRow = [...Array(parsedData.length).keys()].map(rowIndex => rectangleCoordinates.filt

        let rectangleCount = rectangleCoordinates.length;

        for (let i = 0; i < rectangleCoordinates.length; i++) {
            const adjacentRectangleRowCount = rectangleCoordinates.filter(coordinate => coordinate.x === rectangleCoordinates[i].x && (coordinate.y - 2 === rectangleCoordinates[i].y)).length;
            const adjacentRectangleColumnCount = rectangleCoordinates.filter(coordinate => coordinate.y === rectangleCoordinates[i].y && (coordinate.x - 2 === rectangleCoordinates[i].x)).length;
            rectangleCount += adjacentRectangleRowCount + adjacentRectangleColumnCount;
        }

        return rectangleCount;
  }
}

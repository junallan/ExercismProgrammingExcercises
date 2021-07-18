export class Rectangles {
    static isBaseRectangle(rowIndex, columnIndex, data) {
        if (rowIndex < 1 || (rowIndex > data.length - 2)) return false;
        if (columnIndex < 1 || (columnIndex > data[0].length - 2)) return false;
     
        return (data[rowIndex - 1][columnIndex] === '-' && data[rowIndex + 1][columnIndex] === '-' &&
            data[rowIndex][columnIndex - 1] === '|' && data[rowIndex][columnIndex + 1] === '|' &&
            data[rowIndex - 1][columnIndex - 1] === '+' && data[rowIndex - 1][columnIndex + 1] === '+' &&
            data[rowIndex + 1][columnIndex - 1] === '+' && data[rowIndex + 1][columnIndex + 1] === '+')
    }

    static isRectangleOfHeightOne(rowIndex, columnIndex, data) {
        if (rowIndex > data.length - 2) return false;
        if (columnIndex > data[0].length - 4) return false;
      
        return (data[rowIndex][columnIndex] === '+' && data[rowIndex][columnIndex + 1] === '-' && data[rowIndex][columnIndex + 2] === '-' && data[rowIndex][columnIndex + 3] === '+' &&
                data[rowIndex + 1][columnIndex] === '+' && data[rowIndex + 1][columnIndex + 1] === '-' && data[rowIndex + 1][columnIndex + 2] === '-' && data[rowIndex + 1][columnIndex + 3] === '+');
    }

    static isRectangleOfWidthOne(rowIndex, columnIndex, data) {
        if ((rowIndex + 2) > data.length - 1) return false;
        if ((columnIndex + 1) > data[0].length - 1) return false;
        //console.log(data);
        //console.log(data[rowIndex][columnIndex+1]);
        return (data[rowIndex][columnIndex] === '+' && data[rowIndex][columnIndex + 1] === '+' &&
                data[rowIndex + 1][columnIndex] === '|' && data[rowIndex + 1][columnIndex + 1] === '|' &&
                data[rowIndex + 2][columnIndex] === '+' && data[rowIndex + 2][columnIndex + 1] === '+');
    }

    static count(data) {
      //console.log(data.map(row => [...row]))
        let rectangleCoordinates = [];
        let parsedData = data.map(row => [...row]);

        for (let rowIndex = 0; rowIndex < parsedData.length; rowIndex++) {
            for (let columnIndex = 0; columnIndex < parsedData[0].length; columnIndex++) {
                if (Rectangles.isBaseRectangle(rowIndex, columnIndex, parsedData) ||
                    Rectangles.isRectangleOfHeightOne(rowIndex, columnIndex, parsedData) || 
                    Rectangles.isRectangleOfWidthOne(rowIndex, columnIndex, parsedData)) {
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

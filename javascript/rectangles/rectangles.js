export class Rectangles {
    static countBottomCornerPair(topCornerPair, data) {
        let bottomCornerMatches = 0;
        for (let rowIndex = topCornerPair.leftCorner.x + 1; rowIndex < data.length; rowIndex++) {
            //console.log(data[rowIndex][topCornerPair.leftCorner.y]);
            //console.log(data[rowIndex][topCornerPair.rightCorner.y]);
            if (data[rowIndex][topCornerPair.leftCorner.y] === '+' && data[rowIndex][topCornerPair.rightCorner.y] === '+') {
                bottomCornerMatches++;
            }
        }

        return bottomCornerMatches;
    }

    static count(data) {
        let rectangleCoordinates = [];
        let parsedData = data.map(row => [...row]);

        //row by row find those with more than 1 +, get all permutations and combinations of the column positions for pairs
            // if found pair matches of + go through sequential rows that match column position for left + and right +
                    //Add to count

        let cornerPairs = [];

        for (let rowIndex = 0; rowIndex < parsedData.length; rowIndex++) {
            let columnIndexesOfCorners = [];

            for (let columnIndex = 0; columnIndex < parsedData[0].length; columnIndex++) {
                if (parsedData[rowIndex][columnIndex] === '+') columnIndexesOfCorners.push(columnIndex);
            }

            console.log(columnIndexesOfCorners);
            for (let i = 0; i < columnIndexesOfCorners.length-1; i++) {
                for (let j = i+1; j < columnIndexesOfCorners.length; j++) {
                    cornerPairs.push({ leftCorner: { x: rowIndex, y: i }, rightCorner: { x: rowIndex, y: columnIndexesOfCorners[j] } });
                }
            }
        }

        let rectangleCount = 0;

        cornerPairs.forEach(topCornerPair => rectangleCount += this.countBottomCornerPair(topCornerPair, parsedData));

        //cornerPairs.forEach(coordinate =>
        //    rectangleCount += cornerPairs.filter(element => element.leftCorner.y === coordinate.leftCorner.y
        //                                                                                    && element.rightCorner.y === coordinate.rightCorner.y
        //                                                                                    && element.leftCorner.x !== coordinate.leftCorner.x
        //        && element.rightCorner.x !== coordinate.rightCorner.x).length
        //);

        console.log(cornerPairs);

        //for (let rowIndex = 0; rowIndex < parsedData.length; rowIndex++) {
        //    for (let columnIndex = 0; columnIndex < parsedData[0].length; columnIndex++) {
        //        if (Rectangles.isBaseRectangle(rowIndex, columnIndex, parsedData) ||
        //            Rectangles.isRectangleOfHeightOne(rowIndex, columnIndex, parsedData) || 
        //            Rectangles.isRectangleOfWidthOne(rowIndex, columnIndex, parsedData) ||
        //            Rectangles.isSquareOneByOne(rowIndex,columnIndex, parsedData)) {

        //            rectangleCoordinates.push({x: rowIndex, y: columnIndex });
        //        }
        //    }
        //}

        //let rectangleCount = rectangleCoordinates.length;

        return rectangleCount;
    }
}

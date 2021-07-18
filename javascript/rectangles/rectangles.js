export class Rectangles {
    static countBottomCornerPair(topCornerPair, data) {
        let bottomCornerMatches = 0;
        for (let rowIndex = topCornerPair.leftCorner.x + 1; rowIndex < data.length; rowIndex++) {
            if (data[rowIndex][topCornerPair.leftCorner.y] === '+' && data[rowIndex][topCornerPair.rightCorner.y] === '+') {
                let isValidSide = true;

                for (let sideRowIndex = topCornerPair.leftCorner.x + 1; sideRowIndex < rowIndex; sideRowIndex++) {         
                    if ((data[sideRowIndex][topCornerPair.leftCorner.y] !== '|' && data[sideRowIndex][topCornerPair.leftCorner.y] !== '+') ||
                        (data[sideRowIndex][topCornerPair.rightCorner.y] !== '|' && data[sideRowIndex][topCornerPair.rightCorner.y] !== '+')) {
                        isValidSide = false;
                        break;
                    }
                }

                if(isValidSide) bottomCornerMatches++;
            }
        }

        return bottomCornerMatches;
    }

    static isTopBottomComplete(columnIndexesOfCorners, startIndex, endIndex, data, dataRowIndex) {
        let isValidSide = true;

        for (let sideColumnIndex = columnIndexesOfCorners[startIndex] + 1; sideColumnIndex < columnIndexesOfCorners[endIndex]; sideColumnIndex++) {
            if (data[dataRowIndex][sideColumnIndex] !== '-' && data[dataRowIndex][sideColumnIndex] !== '+') {
                isValidSide = false;
                break;
            }
        }

        return isValidSide;
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

            for (let i = 0; i < columnIndexesOfCorners.length-1; i++) {
                for (let j = i + 1; j < columnIndexesOfCorners.length; j++) {
                    //let isValidSide = true;
                    
                    //for (let sideColumnIndex = columnIndexesOfCorners[i] + 1; sideColumnIndex < columnIndexesOfCorners[j]; sideColumnIndex++) {
                    //    if (data[rowIndex][sideColumnIndex] !== '-' && data[rowIndex][sideColumnIndex] !== '+') {
                    //        isValidSide = false;
                    //        break;
                    //    }
                    //}
          
                    if (this.isTopBottomComplete(columnIndexesOfCorners, i, j, parsedData, rowIndex)) cornerPairs.push({ leftCorner: { x: rowIndex, y: columnIndexesOfCorners[i] }, rightCorner: { x: rowIndex, y: columnIndexesOfCorners[j] } });
                }
            }
        }

        let rectangleCount = 0;

        cornerPairs.forEach(topCornerPair => rectangleCount += this.countBottomCornerPair(topCornerPair, parsedData));

        return rectangleCount;
    }
}

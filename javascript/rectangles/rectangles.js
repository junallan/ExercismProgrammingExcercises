export class Rectangles {
    static countBottomCornerPair(topCornerPair, data) {
        let bottomCornerMatches = 0;
        for (let rowIndex = topCornerPair.leftCorner.x + 1; rowIndex < data.length; rowIndex++) {
            if (data[rowIndex][topCornerPair.leftCorner.y] === '+' && data[rowIndex][topCornerPair.rightCorner.y] === '+') {
                if(this.isLeftToRightComplete(data, rowIndex, topCornerPair)) bottomCornerMatches++;
            }
        }

        return bottomCornerMatches;
    }

    static isLeftToRightComplete(data, rowIndex, topCornerPair) {
        let isValidSide = true;

        for (let sideRowIndex = topCornerPair.leftCorner.x + 1; sideRowIndex < rowIndex; sideRowIndex++) {
            if ((data[sideRowIndex][topCornerPair.leftCorner.y] !== '|' && data[sideRowIndex][topCornerPair.leftCorner.y] !== '+') ||
                (data[sideRowIndex][topCornerPair.rightCorner.y] !== '|' && data[sideRowIndex][topCornerPair.rightCorner.y] !== '+')) {
                isValidSide = false;
                break;
            }
        }

        return isValidSide;
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

    static findRowCornerPairs(data, rowIndex) {
        let cornerPairs = [];
        let columnIndexesOfCorners = [];

        for (let columnIndex = 0; columnIndex < data[0].length; columnIndex++) {
            if (data[rowIndex][columnIndex] === '+') columnIndexesOfCorners.push(columnIndex);
        }

        for (let i = 0; i < columnIndexesOfCorners.length - 1; i++) {
            for (let j = i + 1; j < columnIndexesOfCorners.length; j++) {
                if (this.isTopBottomComplete(columnIndexesOfCorners, i, j, data, rowIndex)) cornerPairs.push({ leftCorner: { x: rowIndex, y: columnIndexesOfCorners[i] }, rightCorner: { x: rowIndex, y: columnIndexesOfCorners[j] } });
            }
        }

        return cornerPairs;
    }

    static count(data) {
        let rectangleCoordinates = [];
        let parsedData = data.map(row => [...row]);

        let rectangleCount = 0;

        for (let rowIndex = 0; rowIndex < parsedData.length; rowIndex++) {
            let cornerPairs = this.findRowCornerPairs(parsedData, rowIndex);

            cornerPairs.forEach(topCornerPair => rectangleCount += this.countBottomCornerPair(topCornerPair, parsedData));
        }
    
        return rectangleCount;
    }
}

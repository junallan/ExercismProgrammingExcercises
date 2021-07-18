export class Rectangles {
    static countBottomCornerPair(topCornerPair, data) {
        let bottomCornerMatches = 0;
        for (let rowIndex = topCornerPair.leftCorner.x + 1; rowIndex < data.length; rowIndex++) {
            //console.log(data[rowIndex][topCornerPair.leftCorner.y]);
            //console.log(data[rowIndex][topCornerPair.rightCorner.y]);
            if (data[rowIndex][topCornerPair.leftCorner.y] === '+' && data[rowIndex][topCornerPair.rightCorner.y] === '+') {
                let isValidSide = true;

                for (let sideRowIndex = topCornerPair.leftCorner.x + 1; sideRowIndex < rowIndex; sideRowIndex++) {
                    //console.log(sideRowIndex);
                    //console.log(topCornerPair.leftCorner.y);
                    //console.log(topCornerPair.rightCorner.y);
                    //if (((data[sideRowIndex][topCornerPair.leftCorner.y] !== '|') || (data[sideRowIndex][topCornerPair.rightCorner.y] !== '|')) &&
                    //    ((data[sideRowIndex][topCornerPair.leftCorner.y] !== '+') || (data[sideRowIndex][topCornerPair.rightCorner.y] !== '+'))) {
                    //    isValidSide = false;
                    //    break;
                    //}
            
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

    static count(data) {
        let rectangleCoordinates = [];
        let parsedData = data.map(row => [...row]);

        //row by row find those with more than 1 +, get all permutations and combinations of the column positions for pairs
            // if found pair matches of + go through sequential rows that match column position for left + and right +
                    //Add to count

        let cornerPairs = [];

        //console.log(parsedData.length);
        for (let rowIndex = 0; rowIndex < parsedData.length; rowIndex++) {
            let columnIndexesOfCorners = [];

            for (let columnIndex = 0; columnIndex < parsedData[0].length; columnIndex++) {
                if (parsedData[rowIndex][columnIndex] === '+') columnIndexesOfCorners.push(columnIndex);
            }

            //console.log(columnIndexesOfCorners);
            for (let i = 0; i < columnIndexesOfCorners.length-1; i++) {
                for (let j = i + 1; j < columnIndexesOfCorners.length; j++) {
                    let isValidSide = true;

                    //console.log(`columnIndexesOfCorners[i] + 1: ${columnIndexesOfCorners[i] + 1}`);
                    //console.log(`columnIndexesOfCorners[j]: ${columnIndexesOfCorners[j]}`);
                    
                    for (let sideColumnIndex = columnIndexesOfCorners[i] + 1; sideColumnIndex < columnIndexesOfCorners[j]; sideColumnIndex++) {
                        //console.log(rowIndex);
                        //console.log(rowIndex);
                        //console.log(sideColumnIndex);
                        if (data[rowIndex][sideColumnIndex] !== '-' && data[rowIndex][sideColumnIndex] !== '+') {
                            isValidSide = false;
                            break;
                        }
                    }
                    //console.log(`isValid: ${isValidSide}`);
                    //console.log(`rowIndex:${rowIndex}`);
                    //console.log(`columnIndexesOfCorners[i]:${columnIndexesOfCorners[i]}`);
                    //console.log(`columnIndexesOfCorners[j]:${columnIndexesOfCorners[j]}`);
                    if(isValidSide) cornerPairs.push({ leftCorner: { x: rowIndex, y: columnIndexesOfCorners[i] }, rightCorner: { x: rowIndex, y: columnIndexesOfCorners[j] } });
                }
            }
        }

        let rectangleCount = 0;
        //console.log(cornerPairs);
        cornerPairs.forEach(topCornerPair => rectangleCount += this.countBottomCornerPair(topCornerPair, parsedData));

        //console.log(cornerPairs);

        return rectangleCount;
    }
}

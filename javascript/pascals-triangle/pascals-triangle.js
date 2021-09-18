export const rows = (numRows) => {
	function createPascalsTriangle(numRows) {
		if (numRows === 0) {
			return [];
		}


		let triangle = [];
		
		for (let i = 0; i < numRows; i++) {
			let currentRow = triangle.length === 0 ? [] : triangle[triangle.length-1];
			triangle.push(nextRow(currentRow));
		}

		return triangle;
		//else if (numRows === 1) {
		//	return [[1]];
		//}

		//let triangle = [];

		//for (let i = 0; i < numRows; i++) {
		//	if (i === 0) {
		//		triangle.push([1]);
		//		continue;
		//	}
		//	triangle.push(nextRow(triangle[i]));

		//}
	}

	function nextRow(priorRow) {
		let rowPairs = [];

		if (priorRow.length === 0) return [1];

		rowPairs.push([0, 1]);

		for (let i = 1; i < priorRow.length; i++) {
			rowPairs.push([priorRow[i - 1], priorRow[i]]);
		}

		rowPairs.push([1, 0]);

		return rowPairs.map(([a, b]) => a + b);
	}

	return createPascalsTriangle(numRows);
	//function isInitialPosition(row, column) {
	//	return row === 1 && column === 1;
	//}

	//function isLeftSideSum(column) {
	//	return (column - 1) > 0;
	//}

	//function isRightSideSum(column, columnEdge) {
	//	return column < columnEdge;
	//}

	//function lookupLeftSide(triangle, row, column) {
	//	return triangle[row - 2][column - 2];
	//}

	//function lookupRightSide(triangle, row, column) {
	//	return triangle[row - 2][column - 1]
	//}

	//function createPascalsTriangle(numRows) {
	//	let triangle = [];

	//	for (let i = 1; i <= numRows; i++) {
	//		let lineValues = [];

	//		for (let j = 1; j <= i; j++) {
	//			let leftSideSum = 0;
	//			let rightSideSum = 0;

	//			if (isInitialPosition(i, j)) lineValues.push(1);
	//			else {
	//				if (isLeftSideSum(j)) leftSideSum = lookupLeftSide(triangle, i, j);
	//				if (isRightSideSum(j, i)) rightSideSum = lookupRightSide(triangle, i, j);

	//				lineValues.push(leftSideSum + rightSideSum);
	//			}
	//		}

	//		triangle.push(lineValues)
	//	}

	//	return triangle;
	//}
	
	//return createPascalsTriangle(numRows);
};

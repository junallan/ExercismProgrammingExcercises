export const rows = (numRows) => {
	function isInitialPosition(row, column) {
		return row === 1 && column === 1;
	}

	function isLeftSideSum(column) {
		return (column - 1) > 0;
	}

	function isRightSideSum(column, columnEdge) {
		return column < columnEdge;
	}

	function lookupLeftSide(triangle, row, column) {
		return triangle[row - 2][column - 2];
	}

	function lookupRightSide(triangle, row, column) {
		return triangle[row - 2][column - 1]
	}

	function createPascalsTriangle(numRows) {
		let triangle = [];

		for (let i = 1; i <= numRows; i++) {
			let lineValues = [];

			for (let j = 1; j <= i; j++) {
				let leftSideSum = 0;
				let rightSideSum = 0;

				if (isInitialPosition(i, j)) lineValues.push(1);
				else {
					if (isLeftSideSum(j)) leftSideSum = lookupLeftSide(triangle, i, j);
					if (isRightSideSum(j, i)) rightSideSum = lookupRightSide(triangle, i, j);

					lineValues.push(leftSideSum + rightSideSum);
				}
			}

			triangle.push(lineValues)
		}

		return triangle;
	}
	
	return createPascalsTriangle(numRows);
};

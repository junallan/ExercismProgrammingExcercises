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
};

export const rows = (numRows) => {
	function createPascalsTriangle(numRows) {
		let triangle = [];
		
		for (let i = 0; i < numRows; i++) {
			triangle.push(nextRow(triangle.length === 0 ? [] : triangle[triangle.length - 1]));
		}

		return triangle;
	}

	function pairs(priorRow) {
		return [[0, 1], ...Array.from(Array(priorRow.length-1).keys()).map(i => [priorRow[i], priorRow[i + 1]]), [1, 0]];
	}
	
	function nextRow(priorRow) {
		if (priorRow.length === 0) return [1];
		
		return pairs(priorRow).map(([a, b]) => a + b);
	}

	return createPascalsTriangle(numRows);
};

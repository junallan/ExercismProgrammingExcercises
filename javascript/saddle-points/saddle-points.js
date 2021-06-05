export const saddlePoints = (grid) => {
	let points = [];
	
	for (let i = 0; i < grid[0].length; i++) {
		let columnValues = getColumn(i, grid);
		let columnMinValue = Math.min(...columnValues);
		let idxRow = columnValues.indexOf(columnMinValue);
	
		points.push(getSaddlePoints(idxRow, i, grid, columnValues, columnMinValue));
	}

	return points.flat();
};


function getColumn(columnIndex, grid) {
	let columnValues = [];

	for (let rowIndex = 0; rowIndex < grid.length; rowIndex++) {
		columnValues.push(grid[rowIndex][columnIndex]);
	}

	return columnValues;
}


function getSaddlePoints(idxRow, idxColumn, grid, columnValues, columnMinValue) {
	let points = [];

	while (idxRow !== -1) {
		let rowMaxValue = Math.max(...grid[idxRow]);

		if (grid[idxRow][idxColumn] === rowMaxValue) {
			points.push({ row: idxRow + 1, column: idxColumn + 1 });
		}

		idxRow = columnValues.indexOf(columnMinValue, idxRow + 1);
	}
	
	return points;
}
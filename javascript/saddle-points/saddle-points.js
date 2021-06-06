export const saddlePoints = (grid) => {
	let points = [];

	for (let i = 0; i < grid[0].length; i++) {
		let columnValues = grid.map(rowNumbers => rowNumbers[i]);
		let columnMinValue = Math.min(...columnValues);
		let idxRow = columnValues.indexOf(columnMinValue);

		while (idxRow !== -1) {
			if (grid[idxRow].every(x => columnMinValue >= x)) {
				points.push({ row: idxRow + 1, column: i + 1 });
			}

			idxRow = columnValues.indexOf(columnMinValue, idxRow + 1);
		}
	}

	return points;
};
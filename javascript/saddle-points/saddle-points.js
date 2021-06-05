export const saddlePoints = (grid) => {
	let saddlePoints = [];
	let coordinatesPointsOfInterestRows = [];

	for (let i = 0; i < grid.length; i++) {
		let gridRow = grid[i];
	
		let rowMaxValue = Math.max(...gridRow);
		
		let idxRow = gridRow.indexOf(rowMaxValue);
		
		while (idxRow !== -1) {
			coordinatesPointsOfInterestRows.push({ row: i + 1, column: idxRow + 1 });

			idxRow = gridRow.indexOf(rowMaxValue, idxRow + 1);
		}	
	}


	let coordinatesPointsOfInterestColumns = [];
	
	for (let i = 0; i < grid[0].length; i++) {
		let columnValues = [];
		for (let j = 0; j < grid.length; j++) {
			columnValues.push(grid[j][i]);
		}
		
		let columnMinValue = Math.min(...columnValues);
	
		let idxColumn = columnValues.indexOf(columnMinValue);
	
		while (idxColumn !== -1) {
			coordinatesPointsOfInterestColumns.push({ row: idxColumn + 1, column: i + 1 });

			idxColumn = columnValues.indexOf(columnMinValue, idxColumn + 1);
		}
	}


	for (let i = 0; i < coordinatesPointsOfInterestRows.length; i++) {
		const isMatch = coordinatesPointsOfInterestColumns.some(item => item.row === coordinatesPointsOfInterestRows[i].row && item.column === coordinatesPointsOfInterestRows[i].column);

		if (isMatch){
			saddlePoints.push(coordinatesPointsOfInterestRows[i]);
		}
	}

	console.log(saddlePoints);

	return saddlePoints;
};

export const saddlePoints = (grid) => {
	let saddlePoints = [];
	
	for (let i = 0; i < grid[0].length; i++) {
		let columnValues = [];
		for (let j = 0; j < grid.length; j++) {
			columnValues.push(grid[j][i]);
		}
		
		let columnMinValue = Math.min(...columnValues);
	
		let idxRow = columnValues.indexOf(columnMinValue);
	
		while (idxRow !== -1) {
			let rowMaxValue = Math.max(...grid[idxRow]);

			if (grid[idxRow][i] === rowMaxValue) {
				saddlePoints.push({ row: idxRow + 1, column: i + 1 });
			}
			
			idxRow = columnValues.indexOf(columnMinValue, idxRow + 1);
		}
	}

	return saddlePoints;
};

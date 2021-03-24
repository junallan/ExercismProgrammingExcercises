const MineField = '*';
const EmptyField = ' ';

export const annotate = (input) => {
	let evaluatedInput = [];
	
	for (let rowIndex = 0; rowIndex < input.length; rowIndex++) {
		let evaluatedLine = '';

		for (let columnIndex = 0; columnIndex < input[rowIndex].length; columnIndex++) {
			if (input[rowIndex][columnIndex] === MineField) {
				evaluatedLine += MineField;
			}
			else {
				let mineFieldCount = mineCount(rowIndex, columnIndex, input);
				evaluatedLine += mineFieldCount === 0 ? EmptyField : mineFieldCount.toString();
			}
		}

		evaluatedInput.push(evaluatedLine);
	}

	return evaluatedInput;
};

function mineCount(xCoordinate, yCoordinate, input) {
	let isCoordinateBoard = (xCoord, yCoord) => (xCoord >= 0 && yCoord >= 0 && xCoord < input.length && yCoord < input[xCoord].length);

	let surroudingNeighbors = [[xCoordinate - 1, yCoordinate - 1], [xCoordinate - 1, yCoordinate], [xCoordinate - 1, yCoordinate + 1],
							   [xCoordinate, yCoordinate - 1], [xCoordinate, yCoordinate + 1],
							   [xCoordinate + 1, yCoordinate - 1], [xCoordinate + 1, yCoordinate], [xCoordinate + 1, yCoordinate + 1]];

	return surroudingNeighbors.reduce((accumulator, coordinate) =>
								accumulator + (isCoordinateBoard(coordinate[0], coordinate[1]) && input[coordinate[0]][coordinate[1]] === MineField ? 1 : 0), 0); 
}
const MineField = '*';
const EmptyField = ' ';

export const annotate = (input) => {
	if (isAllElementsSetTo(EmptyField, input) || isAllElementsSetTo(MineField, input)) {
		return input;
	}

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

function isAllElementsSetTo(element, input) {
	return input.reduce((accumulator, currentValue) => accumulator && [...currentValue].every(x => x === element), true);
}

function isCoordinateInBoard(xCoordinate, yCoordinate, input) {
	return (xCoordinate >= 0 && yCoordinate >= 0 && xCoordinate < input.length && yCoordinate < input[xCoordinate].length);
}

function mineCount(xCoordinate, yCoordinate, input) {
	let surroudingNeighbors = [[xCoordinate - 1, yCoordinate - 1], [xCoordinate - 1, yCoordinate], [xCoordinate - 1, yCoordinate + 1],
							   [xCoordinate, yCoordinate - 1], [xCoordinate, yCoordinate + 1],
							   [xCoordinate + 1, yCoordinate - 1], [xCoordinate + 1, yCoordinate], [xCoordinate + 1, yCoordinate + 1]];


	return surroudingNeighbors.reduce((accumulator, coordinate) =>
									accumulator + (isCoordinateInBoard(coordinate[0], coordinate[1], input) && input[coordinate[0]][coordinate[1]] === MineField ? 1 : 0), 0); 
}
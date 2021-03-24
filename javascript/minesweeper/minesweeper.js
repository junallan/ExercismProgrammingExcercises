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
	let mineFieldCount = 0;
	
	if (isCoordinateInBoard(xCoordinate-1, yCoordinate-1, input) && (input[xCoordinate - 1][yCoordinate - 1] === MineField)) { mineFieldCount++; }	
	if (isCoordinateInBoard(xCoordinate-1, yCoordinate, input) && (input[xCoordinate - 1][yCoordinate] === MineField)) { mineFieldCount++; }
	if (isCoordinateInBoard(xCoordinate-1, yCoordinate+1, input) && (input[xCoordinate - 1][yCoordinate + 1] === MineField)) { mineFieldCount++; }
	if (isCoordinateInBoard(xCoordinate, yCoordinate-1, input) && (input[xCoordinate][yCoordinate - 1] === MineField)) { mineFieldCount++; }
	if (isCoordinateInBoard(xCoordinate, yCoordinate+1, input) && (input[xCoordinate][yCoordinate + 1] === MineField)) { mineFieldCount++;}
	if (isCoordinateInBoard(xCoordinate+1, yCoordinate-1, input) && (input[xCoordinate + 1][yCoordinate - 1] === MineField)) { mineFieldCount++;}
	if (isCoordinateInBoard(xCoordinate+1, yCoordinate, input) && (input[xCoordinate + 1][yCoordinate] === MineField)) { mineFieldCount++;}
	if (isCoordinateInBoard(xCoordinate+1, yCoordinate+1, input) && (input[xCoordinate + 1][yCoordinate + 1] === MineField)) { mineFieldCount++;}

	return mineFieldCount;
}
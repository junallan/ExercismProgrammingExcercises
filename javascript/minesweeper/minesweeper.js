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

function mineCount(xCoordinate, yCoordinate, input) {
	let mineFieldCount = 0;
	
	if (xCoordinate > 0) {
		if (yCoordinate > 0) {
			if (input[xCoordinate - 1][yCoordinate - 1] === MineField) { mineFieldCount++;}	
		}

		if (input[xCoordinate - 1][yCoordinate] === MineField) { mineFieldCount++;}

		if (yCoordinate < input[xCoordinate - 1].length - 1) {
			if (input[xCoordinate - 1][yCoordinate + 1] === MineField) { mineFieldCount++;}
		}
	}

	if (yCoordinate > 0) {
		if (input[xCoordinate][yCoordinate - 1] === MineField) { mineFieldCount++;}
	}

	if (yCoordinate < input[xCoordinate].length) {
		if (input[xCoordinate][yCoordinate + 1] === MineField) { mineFieldCount++;}
	}

	if (xCoordinate + 1 < input.length) {
		if (yCoordinate > 0) {
			if (input[xCoordinate + 1][yCoordinate - 1] === MineField) { mineFieldCount++;}
		}

		if (input[xCoordinate + 1][yCoordinate] === MineField) { mineFieldCount++;}

		if (yCoordinate + 1 < input[xCoordinate + 1].length) {
			if (input[xCoordinate + 1][yCoordinate + 1] === MineField) { mineFieldCount++;}
		}
	}

	return mineFieldCount;
}
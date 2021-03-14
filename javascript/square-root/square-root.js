export const squareRoot = (number) => {
	//TODO: ALGORITHM STEPS
	// Bit split
	// Evaluate _
	// Subtract
	// Bring down and double digit
	
	let binaryComponents = splitToBinaryComponents(number);
	let placeholderNumber = undefined;
	let maskedNumber = undefined;
	let evaluatedResult = [];
	let subtractedResult = 0;

	for (let i = 0; i < binaryComponents.length; i++) {
		subtractedResult = subtractedResult << 2;
		subtractedResult += binaryComponents[i];

		console.log('Before placeholder evaluation: maskedNumber, subractedValue: ' + maskedNumber + ',' + subtractedResult);
		placeholderNumber = placeholderEvaluation(maskedNumber, subtractedResult);

		if (maskedNumber === undefined) {
			maskedNumber = placeholderNumber;
		}

		if (placeholderNumber !== 0) {
			subtractedResult = subtractedResult - maskedNumber;

		}
	
		maskedNumber = maskedNumber << 1;


		evaluatedResult.push(placeholderNumber);
	}

	console.log("split values: " + evaluatedResult);
	return evaluatedResult.reduce(function (accumulator, currentValue, currentIndex, array) {
		return accumulator + (currentValue === 0 && currentIndex === (array.length - 1) ? 0 : (currentValue * 2) ** ((array.length - 1) - currentIndex));
	}, 0);
};

function splitToBinaryComponents(number) {
	//let number = 5;//255;//81;
	let maskedNumber = 3;
	let evaluatedNumber = 0;
	let shifts = 0;
	let numberParsed = [];

	do {
		evaluatedNumber = number & maskedNumber;
		numberParsed.push(evaluatedNumber >> shifts);
		shifts += 2;
		maskedNumber = maskedNumber << 2;
	} while (number >= maskedNumber)

	evaluatedNumber = number & maskedNumber;

	let result = evaluatedNumber >> shifts;
	if (result > 0) {
		numberParsed.push(result);
	}

	numberParsed = numberParsed.reverse();

	return numberParsed;
}

function placeholderEvaluation(maskedNumber, subtractedResult) {
	if (maskedNumber === undefined) { return 1; }

	if ((maskedNumber << 1) <= subtractedResult) {
		return 1;
	} else {
		return 0;
	}
}
//
// This is only a SKELETON file for the 'Square root' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export const squareRoot = (number) => {
	//TODO: ALGORITHM STEPS
	// Bit split
	// Evaluate _
	// Subtract
	// Bring down and double digit
	
	let binaryComponents = splitToBinaryComponents(number);
	let placeholderNumber = undefined;
	let placeholderEvaluationResult = 0;
	let evaluatedResult = [];
	let subtractedResult = 0;

	for (let i = 0; i < binaryComponents.length; i++) {
		subtractedResult += binaryComponents[i];
		placeholderEvaluationResult = placeholderEvaluation(binaryComponents[i], placeholderNumber);
		evaluatedResult.push(placeholderEvaluationResult);

		placeholderNumber = placeholderEvaluationResult;
		subtractedResult = (subtractedResult - placeholderNumber) << 2;
	}

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

function placeholderEvaluation(number, placeholderNumber) {
	if (placeholderNumber === undefined) { return number; }

	let evaluatedNumber = (placeholderNumber << 2) + 1;
	if (number >= evaluatedNumber) {
		return 1;
	}
	else {
		return 0;
	}
}
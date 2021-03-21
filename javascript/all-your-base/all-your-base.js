export const convert = (sourceNumbers, sourceBase, targetBase) => {
	let numberToEvaluate = getNumber(sourceNumbers, sourceBase);
	if (sourceBase <= 1) { throw "Wrong input base" };
	if (targetBase <= 1) { throw "Wrong output base" };
	if (!isFormatValid(sourceNumbers, numberToEvaluate, sourceBase)) { throw "Input has wrong format"; }

	let accumulatedNumber = [];
	let numberCalculated = getNumberComponentsLessThanOrEqualTo(numberToEvaluate, targetBase);

	let lastExponent = numberCalculated[numberCalculated.length - 1].exponentNumber;
	for (let i = 0; i < numberCalculated.length; i++) {
		for (let j = numberCalculated[i].exponentNumber+1; j < lastExponent; j++) {
			accumulatedNumber.push(0);
		}

		accumulatedNumber.push(numberCalculated[i].multipliedNumber);

		lastExponent = numberCalculated[i].exponentNumber;	
	}

	return accumulatedNumber;
};

function isFormatValid(sourceNumbers, numberToEvaluate, sourceBase) {
	let negativeNumbers = sourceNumbers.filter(x => x < 0);
	let numbersGreaterOrEqualToBase = sourceNumbers.filter(x => x >= sourceBase);
	let isNotNegative = negativeNumbers.length === 0;
	let isCorrectPositiveNumber = numbersGreaterOrEqualToBase.length === 0;

	let isFormatValid = (sourceNumbers.length === 1) || (sourceNumbers.length > 1 && numberToEvaluate > 0 && sourceNumbers[0] !== 0 && isNotNegative && isCorrectPositiveNumber);
	return isFormatValid;
}

function getNumberComponentsLessThanOrEqualTo(comparedNumber, baseNumber) {
	if (comparedNumber < baseNumber) {
		return [{ multipliedNumber: comparedNumber , baseNumber: baseNumber , exponentNumber: 0}];
	}

	let closestNumberLessThanOrEqualToComparedNumber = [];
	
	let currentValue = null;
	for (let i = baseNumber - 1; i > 0; i--) {
		let exponentNumber = 0;
		let evaluatedNumber = 0;

		while (evaluatedNumber <= comparedNumber) {	
			evaluatedNumber = i * baseNumber ** exponentNumber;	
			exponentNumber += 1;
		}

		exponentNumber -= 2;

		let evaluatedResult = i * baseNumber ** exponentNumber;

		if (currentValue === null) {
			currentValue = { multipliedNumber: i, exponentNumber: exponentNumber, result: evaluatedResult };		
		}
		else if (currentValue.result < i * baseNumber ** exponentNumber) {
			currentValue = { multipliedNumber: i, exponentNumber: exponentNumber , result: evaluatedResult };
		}
	}

	closestNumberLessThanOrEqualToComparedNumber.push({ multipliedNumber: currentValue.multipliedNumber, baseNumber: baseNumber, exponentNumber: currentValue.exponentNumber });

	if (comparedNumber === currentValue.evaluation) {
		return closestNumberLessThanOrEqualToComparedNumber;
	}
	else {
		return closestNumberLessThanOrEqualToComparedNumber.concat(getNumberComponentsLessThanOrEqualTo(comparedNumber - currentValue.result, baseNumber));
	}
}

function getNumber(sourceNumbers, sourceBase) {
	let number = 0;

	for (let i = 0; i < sourceNumbers.length; i++) {
		number += sourceNumbers[i] * sourceBase ** (sourceNumbers.length- 1 - i);
	}

	return number;
}


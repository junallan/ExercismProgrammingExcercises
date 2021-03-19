export const convert = (sourceNumbers, sourceBase, targetBase) => {
	let accumulatedNumber = [];
	//console.log('num: ' + getNumber(sourceNumbers, sourceBase));
	let numberCalculated = getNumberComponentsLessThanOrEqualTo(getNumber(sourceNumbers, sourceBase), targetBase);

	let lastExponent = numberCalculated[numberCalculated.length - 1].exponentNumber;
	for (let i = 0; i < numberCalculated.length; i++) {
		console.log('numberCalculated[i]:' + numberCalculated[i].multipliedNumber + ' ' + numberCalculated[i].baseNumber + ' ' + numberCalculated[i].exponentNumber);
		

		for (let j = numberCalculated[i].exponentNumber+1; j < lastExponent; j++) {
			accumulatedNumber.push(0);
		}

		accumulatedNumber.push(numberCalculated[i].multipliedNumber);

		lastExponent = numberCalculated[i].exponentNumber;
		
	}

	for (let i = 0; i < accumulatedNumber.length; i++) {
		console.log('accumulatedNumber[i]: ' + accumulatedNumber[i]);
	}

	return accumulatedNumber;
};

function getNumberComponentsLessThanOrEqualTo(comparedNumber, baseNumber) {
	if (comparedNumber < baseNumber) {
		//console.log('comparedNumber < baseNumber:' + comparedNumber + ' ' + baseNumber);
		return [{ multipliedNumber: comparedNumber , baseNumber: baseNumber , exponentNumber: 0}];
	}

	let closestNumberLessThanOrEqualToComparedNumber = [];
	let exponentNumber = 1;
	
	for (let i = baseNumber-1; i > 0; i--) {
		let evaluatedNumber = 0
		do {		
			evaluatedNumber = i * baseNumber ** exponentNumber;
			
			exponentNumber += 1;
			//console.log(`In for: ${i},${baseNumber},${exponentNumber},${evaluatedNumber}`);
		} while (evaluatedNumber <= comparedNumber)
		exponentNumber -= 2;
		closestNumberLessThanOrEqualToComparedNumber.push({ multipliedNumber: i, baseNumber: baseNumber, exponentNumber: exponentNumber });
		//console.log(`In for: ${i},${baseNumber},${exponentNumber}`);
	}

	let result = 0;

	for (let i = 0; i < closestNumberLessThanOrEqualToComparedNumber.length; i++) {
		result += closestNumberLessThanOrEqualToComparedNumber[i].multipliedNumber * baseNumber ** closestNumberLessThanOrEqualToComparedNumber[i].exponentNumber;
	}

	//console.log('resut == comparedNumber: ' + result + ' ' + comparedNumber);

	if (result === comparedNumber) {
		return closestNumberLessThanOrEqualToComparedNumber;
	}

	//return closestNumberLessThanOrEqualToComparedNumber + getNumberComponentsLessThanOrEqualTo(comparedNumber - result, baseNumber);
	//console.log('recursive:' + (comparedNumber - result));
	return closestNumberLessThanOrEqualToComparedNumber.concat(getNumberComponentsLessThanOrEqualTo(comparedNumber - result, baseNumber)); 
	
	//return closestNumberLessThanOrEqualToComparedNumber;
}

function getNumber(sourceNumbers, sourceBase) {
	let number = 0;

	for (let i = 0; i < sourceNumbers.length; i++) {
		number += sourceNumbers[i] * sourceBase ** i;
	}

	return number;
}

//function getLatestExponent(targetBase, number) {
//	let accumulatedNumber = 0;
//	let i = 0;
//	do {
//		accumulatedNumber = targetBase ** i;
//		i += 1;

//	} while ((targetBase ** i) <= number)

//	return i - 1;
//}

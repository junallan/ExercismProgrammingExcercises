import { basename } from "path";

export const convert = (sourceNumbers, sourceBase, targetBase) => {
	let accumulatedNumber = [];

	let numberCalculated = getNumberComponentsLessThanOrEqualTo(getNumber(sourceNumbers, sourceBase), targetBase);
	accumulatedNumber.push(numberCalculated);

	return accumulatedNumber.map(x => x.multipledNumber);
	//let savedExponents = [];
	//let number = getNumber(sourceNumber);

	//savedExponents.push(1 * targetBase ** getLatestExponent(targetBase, number)); //TODO
	//let accumulatedNumber = targetBase ** savedExponents[savedExponents.length-1];
	
	//let remaindingNumber = number - accumulatedNumber;

	//if (accumulatedNumber === number) {
	//	console.log('savedExponents: ' + savedExponents);
	//	return savedExponents;
	//}

	//console.log('number: ' + number);
	//console.log('accumulatedNumber: ' + accumulatedNumber);
	//console.log('savedExponents.length: ' + savedExponents.length);
	//console.log('savedExponents[0]: ' + savedExponents[0]);
	//console.log('savedExponents[savedExponents.length-1]: ' + savedExponents[savedExponents.length - 1]);

	//for (let i = 1; i < savedExponents.length; i++) {
	//	let evaluatedNumber = accumulatedNumber + (targetBase ** i);
	//	if (evaluatedNumber === number) {
	//		savedExponents.push(i);
	//	}
	//}

	//return savedExponents;
	//return [1];
};

function getNumberComponentsLessThanOrEqualTo(comparedNumber, baseNumber) {
	if (comparedNumber < baseNumber) {
		return { multipledNumber: comparedNumber , baseNumber: baseNumber , exponentNumber: 0};
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
		closestNumberLessThanOrEqualToComparedNumber.push({ multipledNumber: i, baseNumber: baseNumber, exponentNumber: exponentNumber });
		console.log(`In for: ${i},${baseNumber},${exponentNumber}`);
	}
	
	return closestNumberLessThanOrEqualToComparedNumber[0];
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

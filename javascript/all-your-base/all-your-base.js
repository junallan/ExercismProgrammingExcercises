export const convert = (sourceNumber, sourceBase, targetBase) => {
	let savedExponents = [];
	let number = getNumber(sourceNumber);

	savedExponents.push(1 * targetBase ** getLatestExponent(targetBase, number)); //TODO
	let accumulatedNumber = targetBase ** savedExponents[savedExponents.length-1];
	
	let remaindingNumber = number - accumulatedNumber;

	if (accumulatedNumber === number) {
		console.log('savedExponents: ' + savedExponents);
		return savedExponents;
	}

	console.log('number: ' + number);
	console.log('accumulatedNumber: ' + accumulatedNumber);
	console.log('savedExponents.length: ' + savedExponents.length);
	console.log('savedExponents[0]: ' + savedExponents[0]);
	console.log('savedExponents[savedExponents.length-1]: ' + savedExponents[savedExponents.length - 1]);

	for (let i = 1; i < savedExponents.length; i++) {
		let evaluatedNumber = accumulatedNumber + (targetBase ** i);
		if (evaluatedNumber === number) {
			savedExponents.push(i);
		}
	}

	return savedExponents;
	//return [1];
};

function getNumber(sourceNumber) {
	let number = 0;

	for (let i = 0; i < sourceNumber.length; i++) {
		number += sourceNumber[i] ** i;
	}

	return number;
}

function getLatestExponent(targetBase, number) {
	let accumulatedNumber = 0;
	let i = 0;
	do {
		accumulatedNumber = targetBase ** i;
		i += 1;

	} while ((targetBase ** i) <= number)

	return i - 1;
}

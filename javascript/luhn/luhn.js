export const valid = (identificationNumber) => {
	if (/[^\d^\s]/.test(identificationNumber)) {
		return false;
	}

	let identificationNumberStrippedNonDigits = identificationNumber.replace(/\s/g, '')
																	.split('')
																	.reverse()
																	.join('');
	let everyOddValueInIdentification = identificationNumberStrippedNonDigits.replace(/(.).?/g, '$1')
																				.split('')
																				.map(Number);
	let everyEvenValueInIdentification = identificationNumberStrippedNonDigits.replace(/.(.)?/g, '$1')
																				.split('')
																				.map(Number);

	if (everyOddValueInIdentification.length === 1 && everyEvenValueInIdentification.length === 0) {
		return false;
	}

	let sumOfEvenValuesInIdentification = everyEvenValueInIdentification.reduce(
		(accumulator, currentValue) => accumulator + (currentValue * 2 <= 9
										? currentValue * 2
										: currentValue * 2 - 9), 0);

	let sumOfOddValuesInIdentification = everyOddValueInIdentification.reduce(
		(accumulator, currentValue) => accumulator + currentValue);

	return (sumOfEvenValuesInIdentification + sumOfOddValuesInIdentification) % 10 === 0;
};

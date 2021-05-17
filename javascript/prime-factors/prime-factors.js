export const primeFactors = (number) => {
	if (number === 1) { return []; }

	let factors = [];
	let startDivisor = 2;
	let factorForNumber = number;
	let value = null;

	do {
		value = firstFactorsOf(factorForNumber, startDivisor);
		factorForNumber = value.result;
		startDivisor = value.factor;

		factors.push(value.factor);

		if (value.result === 1) { return factors; }

	} while (value.result !== 1);

	return factors;
};

function firstFactorsOf(number, startDivisor) {
	for (let i = startDivisor; i <= number; i++) {
		let remainder = number % i;

		if (remainder === 0) {
			return { result: number / i, factor: i };
		}
	}

	return { result: 1, factor: number };
}



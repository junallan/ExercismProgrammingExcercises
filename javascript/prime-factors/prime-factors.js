export const primeFactors = (number) => {
	if (number === 1) { return []; }

	let factors = [];
	let startDivisor = 2;
	let factorForNumber = number;

	do {
		const { result, factor } = firstFactorsOf(factorForNumber, startDivisor);
		factorForNumber = result;
		startDivisor = factor;

		factors.push(factor);

		if (result === 1) { return factors; }

	} while (factorForNumber !== 1);

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



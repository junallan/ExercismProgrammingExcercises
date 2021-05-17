export const primeFactors = (number) => {
	let factors = [];
	let startDivisor = 2;
	let factorForNumber = number;

	while (factorForNumber !== 1) {
		const { result, factor } = firstFactorsOf(factorForNumber, startDivisor);
		factorForNumber = result;
		startDivisor = factor;

		factors.push(factor);
	}

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



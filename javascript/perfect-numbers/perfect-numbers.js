export const classify = (number) => {
	if (number <= 0) { throw new Error('Classification is only possible for natural numbers.') }

	if (number == 1) { return "deficient"; }

	let sumOfFactors = 1;

	for (let i = 2; i < number; i++) {
		if (number % i == 0) {
			sumOfFactors += i;
		}
	}

	if (sumOfFactors === number) {
		return "perfect";
	}
	else if (sumOfFactors > number) {
		return "abundant";
	}
	else {
		return "deficient";
	}
};

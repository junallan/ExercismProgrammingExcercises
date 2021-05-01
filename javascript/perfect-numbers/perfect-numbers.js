export const classify = (number) => {
	if (number <= 0) { throw new Error('Classification is only possible for natural numbers.') }

	if (number == 1) { return "deficient"; }

	let numberFactors = [1];

	for (let i = 2; i < number; i++) {
		if (number % i == 0 && !numberFactors.includes(i)) {
			numberFactors.push(i)
		}
	}

	let sumOfFactors = numberFactors.reduce((accumulator, currentValue) => accumulator + currentValue, 0);

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

export const primeFactors = (number) => {
	let divisors = [];
	let currentDivisor = 2;
	let factorForNumber = number;

	while (factorForNumber !== 1) {
		if (factorForNumber % currentDivisor !== 0) {
			currentDivisor++;
		}
		else {
			divisors.push(currentDivisor);
			factorForNumber /= currentDivisor; 
		}
	}

	return divisors;
};




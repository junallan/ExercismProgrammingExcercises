export const steps = (positiveNumber) => {
	if (positiveNumber <= 0) { throw 'Only positive numbers are allowed'; }

	return positiveNumber === 1 ? 0 : 1 + (positiveNumber % 2 === 0 ? steps(positiveNumber / 2) : steps(3 * positiveNumber + 1));
};

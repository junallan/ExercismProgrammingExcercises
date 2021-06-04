export const largestProduct = (digitSequence, length) => {
	if (digitSequence.length === length) {
		return [...digitSequence].reduce((accumulator, currentValue) => parseInt(accumulator) * parseInt(currentValue));
	}
};

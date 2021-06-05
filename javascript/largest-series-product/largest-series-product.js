export const largestProduct = (digitSequence, length) => {
	if (length < 0) { throw new Error('Span must be greater than zero'); }
	if (!/^\d*$/.test(digitSequence)) { throw new Error('Digits input must only contain digits'); }
	if (digitSequence.length < length) { throw new Error('Span must be smaller than string length'); }
	if (length === 0) { return 1; }

	return findLargestProduct(digitSequence, length);
};

function findLargestProduct(digitSequence, length) {
	const sumOfList = (items) => items.reduce((accumulator, currentValue) => accumulator * currentValue);

	let products = [];

	for (let i = 0; i <= digitSequence.length - length; i++) {
		products.push(sumOfList([...digitSequence].map(Number).slice(i, i + length)));
	}

	return Math.max(...products);
}



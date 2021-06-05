export const largestProduct = (digitSequence, length) => {
	if (length < 0) { throw new Error('Span must be greater than zero'); }
	if (!/^\d*$/.test(digitSequence)) { throw new Error('Digits input must only contain digits'); }

	let sumOfList = (items) => items.reduce((accumulator, currentValue) => accumulator * currentValue);

	if (digitSequence.length < length) { throw new Error('Span must be smaller than string length'); }
	if (length === 0) { return 1; }

	let chunkOfProducts = groupOfAllProducts(digitSequence, length);

	return findLargestProductResultInGroup(chunkOfProducts, sumOfList);
};


function groupOfAllProducts(digitSequence, length) {
	let chunkOfProducts = [];

	for (let i = 0; i <= digitSequence.length - length; i++) {
		chunkOfProducts.push([...digitSequence].map(Number).slice(i, i + length));
	}

	return chunkOfProducts;
}


function findLargestProductResultInGroup(chunkOfProducts, sumOfList) {
	let largestProduct = null;

	for (let i = 0; i < chunkOfProducts.length; i++) {
		if (largestProduct === null) {
			largestProduct = sumOfList(chunkOfProducts[i]);
		}
		else {
			let currentProductEvaluation = sumOfList(chunkOfProducts[i]);

			if (largestProduct < currentProductEvaluation) {
				largestProduct = currentProductEvaluation;
			}
		}
	}

	return largestProduct;
}


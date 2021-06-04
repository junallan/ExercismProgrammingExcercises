export const largestProduct = (digitSequence, length) => {
	if (digitSequence.length === length) {
		return [...digitSequence].reduce((accumulator, currentValue) => parseInt(accumulator) * parseInt(currentValue));
	}

	let chunkOfProducts = [];

	for (let i = 0; i <= digitSequence.length - length; i++) {
		chunkOfProducts.push([...digitSequence].slice(i, i + length));
	}

	let largestProduct = null;

	for (let i = 0; i < chunkOfProducts.length; i++) {
		if (largestProduct === null) {
			largestProduct = chunkOfProducts[i].reduce((accumulator, currentValue) => parseInt(accumulator) * parseInt(currentValue));
		}
		else {
			let currentProductEvaluation = chunkOfProducts[i].reduce((accumulator, currentValue) => parseInt(accumulator) * parseInt(currentValue));

			if (largestProduct < currentProductEvaluation) {
				largestProduct = currentProductEvaluation;
			}
		}
	}

	return largestProduct;
};

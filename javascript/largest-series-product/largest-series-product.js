export const largestProduct = (digitSequence, length) => {
	let sumOfList = (items) => items.reduce((accumulator, currentValue) => parseInt(accumulator) * parseInt(currentValue));

	if (digitSequence.length === length) {
		return sumOfList([...digitSequence]);
	}

	let chunkOfProducts = groupOfAllProducts(digitSequence, length);

	return findLargestProductResultInGroup(chunkOfProducts, sumOfList);
};

function groupOfAllProducts(digitSequence, length) {
	let chunkOfProducts = [];

	for (let i = 0; i <= digitSequence.length - length; i++) {
		chunkOfProducts.push([...digitSequence].slice(i, i + length));
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


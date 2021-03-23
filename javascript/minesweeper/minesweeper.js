export const annotate = (input) => {
	if (input.length <= 1) {
		return input;
	}

	if (isAllElementsSetTo(' ', input) || isAllElementsSetTo('*', input)) {
		return input;
	}

};

function isAllElementsSetTo(element, input) {
	let allElementsSet = true;

	input.forEach(row => allElementsSet = allElementsSet && [...row].every(x => x === element));
	return allElementsSet;
}
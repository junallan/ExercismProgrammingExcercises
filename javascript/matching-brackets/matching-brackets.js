export const isPaired = (data) => {
	let bracketsFound = data.match(/[\[\]{})(]/g);

	if (bracketsFound === null) { return true; }

	let bracketsToFilter = bracketsFound.join('');

	let countBracketsBeforeFilter = bracketsToFilter.length;

	bracketsToFilter = bracketsToFilter.replace(/\[\]|{}|\(\)/g, '');

	if (bracketsToFilter.length === 0) { return true; }
	if (countBracketsBeforeFilter === bracketsToFilter.length) { return false; }

	return isPaired(bracketsToFilter);
};

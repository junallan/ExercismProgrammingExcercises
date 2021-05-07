export const isPaired = (data) => {
	let bracketsFound = data.match(/[\[\]{})(]/g);

	if (bracketsFound === null) { return true; }

	let bracketsToFilter = bracketsFound.join('');

	let countBracketsBeforeFilter = 0; 
	
	do {
		countBracketsBeforeFilter = bracketsToFilter.length;
		bracketsToFilter = bracketsToFilter.replace(/\[\]|{}|\(\)/g, '');
	} while (bracketsToFilter.length > 0 && (countBracketsBeforeFilter !== bracketsToFilter.length))

	return bracketsToFilter.length === 0;
};

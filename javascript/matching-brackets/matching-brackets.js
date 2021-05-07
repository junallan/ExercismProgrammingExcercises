export const isPaired = (data) => {
	let bracketsFound = data.match(/[\[\]{})(]/g);

	if (bracketsFound === null) { return true; }

//	console.log(bracketsFound.join(''));
//	console.log(bracketsFound.join('').replace(/\[\]|{}|\(\)/g, ''));

	let bracketsBeforeFilter = bracketsFound.join('');
	let bracketsToFilter = bracketsBeforeFilter.replace(/\[\]|{}|\(\)/g, '');
	
	while (bracketsToFilter.length > 0 && (bracketsBeforeFilter.length !== bracketsToFilter.length)) {
		bracketsBeforeFilter = bracketsToFilter;
		bracketsToFilter = bracketsBeforeFilter.replace(/\[\]|{}|\(\)/g, '');
	}

	return bracketsToFilter.length === 0;
};

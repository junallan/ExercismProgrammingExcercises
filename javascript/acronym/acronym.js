export const parse = (name) => {
	//let parsedName = name.match(/\w+'?\w?/g);
	let wordMatch = '[A-Za-z]';
	let parsedName = name.match(/[A-Za-z]+'?[A-Za-z]?/g);

	let acronym = '';

	for (let i = 0; i < parsedName.length; i++) {
		acronym += parsedName[i][0].toUpperCase();
	}

	return acronym;
}
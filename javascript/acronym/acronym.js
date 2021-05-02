export const parse = (name) => {
	let parsedName = name.match(/[A-Z]+'?[A-Z]?/gi);

	let acronym = '';

	for (let i = 0; i < parsedName.length; i++) {
		acronym += parsedName[i][0].toUpperCase();
	}

	return acronym;
}
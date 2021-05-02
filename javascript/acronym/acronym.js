export const parse = (name) => {
	let parsedName = name.match(/[A-Z]+'?[A-Z]?/gi);

	return parsedName.reduce((accumulator, word) => { return accumulator + word[0].toUpperCase() }, '');
}
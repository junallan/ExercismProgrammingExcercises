export const parse = (name) => {
	return name.match(/[A-Z]+'?[A-Z]?/gi)
			   .reduce((accumulator, word) => { return accumulator + word[0] }, '')
			   .toUpperCase();
}
export const isIsogram = (word) => {
	return !/([a-z]).*\1/.test(word.toLowerCase());
};

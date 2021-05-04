export const isIsogram = (word) => {
	const repeatPattern = /([a-z]).*?\1/;
	//backreference
	//capturing group
	return !/([a-z]).*\1/.test(word.toLowerCase());
};

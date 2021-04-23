export const isPangram = (sentence) => {
	let sentenceFilteredLetters = sentence.replace(/[^A-Za-z]/g, "").toLowerCase();
	let sentenceFiltredUniqueLetters = new Set(Array.from(sentenceFilteredLetters));
	
	return sentenceFiltredUniqueLetters.size === 26;
};

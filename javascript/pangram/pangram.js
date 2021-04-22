export const isPangram = (sentence) => {
	let sentenceFilteredLetters = sentence.replace(/[^A-Za-z]*/g, "").toLowerCase();
	let sentenceFiltredUniqueLetters = [...new Set(Array.from(sentenceFilteredLetters))];
	let sentenceUniqueLettersSorted = sentenceFiltredUniqueLetters.sort().join("");

	//let sentenceUniqueAlphabetLetters = [...new Set(Array.from(sentence.replace(/^[A-Za-z]+$/, "")))].sort().join("");
	return sentenceUniqueLettersSorted === 'abcdefghijklmnopqrstuvwxyz';
};

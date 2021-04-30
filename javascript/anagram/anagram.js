export const findAnagrams = (wordToCheck, words) => {
	let wordToCheckLowerCase = wordToCheck.toLowerCase();
	let wordToCheckSorted = [...wordToCheckLowerCase].sort().join('');

	let anagrams = [];

	for (let i = 0; i < words.length; i++) {
		let wordLowerCase = words[i].toLowerCase();
		let wordSorted = [...wordLowerCase].sort().join('');
	
		if (wordToCheckLowerCase === wordLowerCase) { continue; }

		if (wordToCheckSorted === wordSorted) {
			anagrams.push(words[i]);
		}
	}

	return anagrams;
};

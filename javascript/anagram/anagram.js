export const findAnagrams = (wordToCheck, words) => {
	let wordToCheckLowerCase = wordToCheck.toLowerCase();
	let wordToCheckSorted = wordToCheckLowerCase.split('').sort().join('');

	return words.reduce((accumulator, currentValue) => {
			let wordLowerCase = currentValue.toLowerCase();
			let wordSorted = wordLowerCase.split('').sort().join('');

			if (wordToCheckLowerCase !== wordLowerCase && wordToCheckSorted === wordSorted) {
				accumulator.push(currentValue);
			}

			return accumulator;
		}, [])
};

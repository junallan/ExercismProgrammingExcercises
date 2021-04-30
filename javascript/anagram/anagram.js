export const findAnagrams = (wordToCheck, words) => {
	let wordToCheckLowerCase = wordToCheck.toLowerCase();
	let wordToCheckSorted = [...wordToCheckLowerCase].sort().join('');

	return words.reduce((accumulator, currentValue) => {
				let wordLowerCase = currentValue.toLowerCase();

				if (wordToCheckLowerCase === wordLowerCase) {
					return accumulator;
				}

				let wordSorted = [...wordLowerCase].sort().join('');

				if (wordToCheckSorted === wordSorted) {
					accumulator.push(currentValue);
				}

				return accumulator;
			}, [])
};

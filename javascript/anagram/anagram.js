export const findAnagrams = (wordToCheck, words) => {
	let wordToCheckLowerCase = wordToCheck.toLowerCase();
	let wordToCheckSorted = wordToCheckLowerCase.split('').sort().join('');

	return words.reduce((accumulator, currentValue) => {
				let wordLowerCase = currentValue.toLowerCase();

				if (wordToCheckLowerCase === wordLowerCase) {
					return accumulator;
				}

				let wordSorted = wordLowerCase.split('').sort().join('');

				if (wordToCheckSorted === wordSorted) {
					accumulator.push(currentValue);
				}

				return accumulator;
			}, [])
};

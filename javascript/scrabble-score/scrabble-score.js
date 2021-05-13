export const score = (word) => {
	let wordMatchCount = (pattern) => {
		let expression = new RegExp(`[${pattern}]`, 'gi');
		let wordMatches = word.match(expression);
		return wordMatches === null ? 0 : wordMatches.length;
	};

	return wordMatchCount('aeioulnrst') +
			(wordMatchCount('dg') * 2) +
			(wordMatchCount('bcmp') * 3) +
			(wordMatchCount('fhvwy') * 4) +
			(wordMatchCount('k') * 5) +
			(wordMatchCount('jx') * 8) +
			(wordMatchCount('qz') * 10);
};

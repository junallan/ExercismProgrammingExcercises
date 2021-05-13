export const score = (word) => {
	let wordMatchCount = (pattern) => {
		let expression = new RegExp(`[${pattern}]`, 'gi');
		let wordMatches = word.match(expression);
		return wordMatches === null ? 0 : wordMatches.length;
	};

	let oneScore = wordMatchCount('aeioulnrst');
	let twoScore = wordMatchCount('dg') * 2;
	let threeScore = wordMatchCount('bcmp') * 3;
	let fourScore = wordMatchCount('fhvwy') * 4;
	let fiveScore = wordMatchCount('k') * 5;
	let eightScore = wordMatchCount('jx') * 8;
	let tenScore = wordMatchCount('qz') * 10;

	return oneScore + twoScore + threeScore + fourScore + fiveScore + eightScore + tenScore;
};

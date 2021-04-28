export const countWords = (sentence) => {
	//const regex = /\w+(?:[']?\w+)*/g;
	const regex = /\w+([']?\w+)*/g;
	const words = sentence.toLowerCase().match(regex);
	let wordMap = {};

	for (let i = 0; i < words.length; i++) {	
		wordMap[words[i]] = wordMap[words[i]] ? ++wordMap[words[i]] : 1;
	}

	return wordMap;
};

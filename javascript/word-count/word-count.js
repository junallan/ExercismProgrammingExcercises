export const countWords = (sentence) => {
	//const regex = /\w+(?:[']?\w+)*/g;
	const words = sentence.toLowerCase().match(/\w+('\w+)?/g);
	let wordMap = {};

	for (let i = 0; i < words.length; i++) {	
		wordMap[words[i]] = wordMap.hasOwnProperty([words[i]]) ? ++wordMap[words[i]] : 1;
	}

	return wordMap;
};

export const recite = (initialBottlesCount, takeDownCount) => {
	let song = [];

	let endOfSongBottleCount = initialBottlesCount - takeDownCount;

	for (let i = initialBottlesCount; i > endOfSongBottleCount; i--) {
		const singularOrPluralFirstVerse = i > 1 ? 's' : '';
		const singularOrPluralSecondVerse = (i - 1) > 1 ? 's' : '';
		const firstSentenceFirstPartPhrase = i === 0 ? 'No more bottles' : `${i} bottle${singularOrPluralFirstVerse}`;
		const firstSentenceSecondPartPhrase = i == 0 ? 'no more bottles' : `${i} bottle${singularOrPluralFirstVerse}`;

		if (song.length !== 0) song.push('');

	
		song.push(`${firstSentenceFirstPartPhrase} of beer on the wall, ${firstSentenceSecondPartPhrase} of beer.`);

		const secondSentenceFirstPartPhrases = ['Go to the store and buy some more,', 'Take it down and pass it around,', 'Take one down and pass it around,'];
		const secondSentenceSecondPartPhrases = ['99 bottles of beer on the wall.', 'no more bottles of beer on the wall.', `${i - 1} bottle${singularOrPluralSecondVerse} of beer on the wall.`];
		const secondSentenceFirstPartPhrase = i > 1 ? `${secondSentenceFirstPartPhrases[2]}` : `${secondSentenceFirstPartPhrases[i]}`;
		const secondSentenceSecondPartPhrase = i > 1 ? `${secondSentenceSecondPartPhrases[2]}` : `${secondSentenceSecondPartPhrases[i]}`;
		
		song.push(`${secondSentenceFirstPartPhrase} ${secondSentenceSecondPartPhrase}`);	
	}

	return song;
};

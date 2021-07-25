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

		if (i === 0)
			song.push('Go to the store and buy some more, 99 bottles of beer on the wall.');
		else if (i === 1)
			song.push(`Take it down and pass it around, no more bottles of beer on the wall.`);
		else 
			song.push(`Take one down and pass it around, ${i - 1} bottle${singularOrPluralSecondVerse} of beer on the wall.`);	
	}

	return song;
};

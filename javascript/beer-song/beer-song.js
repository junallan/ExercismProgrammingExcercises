export const recite = (initialBottlesCount, takeDownCount) => {
	let song = [];

	let endOfSongBottleCount = initialBottlesCount - takeDownCount;

	for (let i = initialBottlesCount; i > endOfSongBottleCount; i--) {
		let singularOrPluralFirstVerse = i > 1 ? 's' : '';
		let singularOrPluralSecondVerse = (i - 1) > 1 ? 's' : '';

		song.push(`${i} bottle${singularOrPluralFirstVerse} of beer on the wall, ${i} bottle${singularOrPluralFirstVerse} of beer.`);

		if (i == 1)
			song.push(`Take it down and pass it around, no more bottles of beer on the wall.`);
		else 
			song.push(`Take one down and pass it around, ${i - 1} bottle${singularOrPluralSecondVerse} of beer on the wall.`);
		
		
	}

	return song;
};

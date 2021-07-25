export const recite = (initialBottlesCount, takeDownCount) => {
	let song = [];

	let endOfSongBottleCount = initialBottlesCount - takeDownCount;

	

	for (let i = initialBottlesCount; i > endOfSongBottleCount; i--) {
		let singularOrPlural = (i - 1) > 1 ? 's' : '';

		song.push(`${i} bottles of beer on the wall, ${i} bottles of beer.`);
		song.push(`Take one down and pass it around, ${i - 1} bottle${singularOrPlural} of beer on the wall.`);
	}

	return song;
};

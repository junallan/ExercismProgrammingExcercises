export const recite = (initialBottlesCount, takeDownCount) => {
	let song = [];

	let endOfSongBottleCount = initialBottlesCount - takeDownCount;

	for (let i = initialBottlesCount; i > endOfSongBottleCount; i--) {
		song.push(`${i} bottles of beer on the wall, ${i} bottles of beer.`);
		song.push(`Take one down and pass it around, ${i - 1} bottles of beer on the wall.`);
	}

	return song;
};

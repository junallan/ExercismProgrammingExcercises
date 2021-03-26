export const compute = (strand1, strand2) => {
	if (strand1.length === 0 && strand2.length === 0) { return 0; }
	if (strand1.length === 0) { throw new Error('left strand must not be empty'); }
	if (strand2.length === 0) { throw new Error('right strand must not be empty'); }
	if (strand1.length !== strand2.length) { throw new Error('left and right strands must be of equal length'); }

	let differenceCount = [...strand1].reduce((accumulator, currentValue, currentIndex) => { return accumulator + (currentValue === strand2[currentIndex] ? 0 : 1) }, 0);

	return differenceCount;
};

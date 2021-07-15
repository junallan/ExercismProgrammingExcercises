export const transpose = (matrix) => {
	let maxRowLength = Math.max(...matrix.map(x => x.length));
	
	return  [...Array(maxRowLength).keys()]
				.map((_, columnIndex) => matrix.reduceRight((accumulator, currentRow) =>
															currentRow[columnIndex]
																? currentRow[columnIndex] + accumulator
																: (accumulator ? ' ' : '') + accumulator, ''));
};

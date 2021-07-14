export const transpose = (matrix) => {
	if (matrix.length === 0) return [];

	let maxRowLength = Math.max(...matrix.map(x => x.length));
	let lastRowLength = matrix[matrix.length-1].length;
	
	let result = [...Array(maxRowLength).keys()]
						.map((_, index) => matrix.map(row => index < row.length ? row[index] : ' ')
						.join(''));

	if (maxRowLength > lastRowLength) result[result.length - 1] = result[result.length - 1].trimRight();
	
	return result;
};

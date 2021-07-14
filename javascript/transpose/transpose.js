export const transpose = (matrix) => {
	if (matrix.length === 0) return [];

	let maxRowLength = Math.max(...matrix.map(x => x.length));
	let lastRowLength = matrix[matrix.length-1].length;

	let result = [...Array(Math.max(...matrix.map(x => x.length))).keys()]
						.map((_, index) => matrix.map(row => index < row.length ? row[index] : ' ')
						.join(''));

	if (maxRowLength > lastRowLength) result[result.length - 1] = result[result.length - 1].trimRight();
	//console.log(maxRowLength);
	//console.log(lastRowLength);
	//console.log(result[result.length - 1]);
	return result;
};

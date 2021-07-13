export const transpose = (matrix) => {
	if (matrix.length === 0) return [];

	let result = [...matrix[0]].map((_, index) => matrix.map(row => row[index]));
	//console.log(result);
	return result.flat();
};

export const rows = (numRows) => {
	//if (numRows === 0) return [];
	//if (numRows === 1) return [[1]];

	let triangle = [];

	for (let i = 1; i <= numRows; i++) {
		for (let j = 1; j <= i; j++) {
			triangle.push([i]);
		}
	}

	return triangle;
};

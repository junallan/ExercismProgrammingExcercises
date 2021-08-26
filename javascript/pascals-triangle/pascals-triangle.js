export const rows = (numRows) => {
	//if (numRows === 0) return [];
	//if (numRows === 1) return [[1]];

	let triangle = [];

	for (let i = 0; i < numRows; i++) {
		triangle.push([i + 1]);

		for (let j = 0; j < i / 2; j++) {

		}
	}

	return triangle;
};

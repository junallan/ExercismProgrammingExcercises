export const rows = (numRows) => {
	let triangle = [];

	for (let i = 1; i <= numRows; i++) {
		let lineValues = [];

		for (let j = 1; j <= i; j++) {
			let leftSideSum = 0;
			let rightSideSum = 0;

			if (i === 1 && j === 1) lineValues.push(1);
			else {			
				if ((j - 1) > 0)	leftSideSum  = triangle[i - 2][j - 2];		
				if (j < i)			rightSideSum = triangle[i - 2][j - 1];				

				lineValues.push(leftSideSum + rightSideSum);
			}	
		}

		triangle.push(lineValues)
	}

	return triangle;
};

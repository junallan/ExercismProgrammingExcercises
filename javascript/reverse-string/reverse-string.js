export const reverseString = (data) => {
	let dataReversed = [];

	for (let i = data.length - 1; i >= 0; i--) {
		dataReversed.push(data[i]);
	}

	return dataReversed.join('');
};

//
// This is only a SKELETON file for the 'Square root' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export const squareRoot = () => {
	//TODO: ALGORITHM STEPS
	// Bit split
	// Evaluate _
	// Subtract
	// Bring down and double digit
	throw new Error('Remove this statement and implement this function');

	let maskedNumber = 3;
	let splitIndex = 2;

	console.log(81 & maskedNumber);
	maskedNumber = maskedNumber << splitIndex;
	console.log((81 & maskedNumber) >> 2);
	maskedNumber = maskedNumber << splitIndex;
	console.log((81 & maskedNumber) >> 4);
	maskedNumber = maskedNumber << splitIndex;
	console.log((81 & maskedNumber) >> 6);



	let number = 81;
	let maskedNumber = 3;

	console.log(maskedNumber);

	do {
		maskedNumber = maskedNumber << 2;
		console.log(maskedNumber);
	} while (number >= maskedNumber)
};

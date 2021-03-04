export const isArmstrongNumber = (numberInput) => {
	let numberInputParsed = `${numberInput}`;
	let numberOfDigits = numberInputParsed.length;
	let total = 0;

	[...numberInputParsed].forEach(function (digit) { total += digit ** numberOfDigits; });

	return total === numberInput;
};
	
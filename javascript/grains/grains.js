/**
 * You can use the bigint type and BigInt global object to support numbers below
 * Number.MIN_SAFE_INTEGER and above NUMBER.MAX_SAFE_INTEGER.
 *
 * https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/BigInt
 */

export const square = (position) => {
	if (position < 1 || position > 64) { throw Error('square must be between 1 and 64'); }
	return (BigInt(2 ** (position - 1))).toString();
};

export const total = () => {
	return [...Array(64).keys()].reduce((accumulator, currentValue) => BigInt(accumulator) + BigInt(square(currentValue + 1)), 0);
};

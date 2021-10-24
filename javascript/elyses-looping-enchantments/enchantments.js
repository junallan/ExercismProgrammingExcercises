// @ts-check

/**
 * Determine how many cards of a certain type there are in the deck
 *
 * @param {number[]} stack
 * @param {number} card
 *
 * @returns {number} number of cards of a single type there are in the deck
 */
export function cardTypeCheck(stack, card) {
	let countForCardType = 0;

	stack.forEach((cardNumber, index) => {
		if (cardNumber === card) countForCardType++;
	});

	return countForCardType;
}

function determineOddOrEvenCard(type) {
	if (type) {
		return function (card) {
			return card % 2 == 0;
		}
	}
	else {
		return function (card) {
			return card % 2 === 1;
		}
	}
}

/**
 * Determine how many cards are odd or even
 *
 * @param {number[]} stack
 * @param {boolean} type the type of value to check for - odd or even
 * @returns {number} number of cards that are either odd or even (depending on `type`)
 */
export function determineOddEvenCards(stack, type) {
	let count = 0;

	const isOfType = determineOddOrEvenCard(type);

	for (const card of stack)
		if (isOfType(card)) count++;

	return count;
}

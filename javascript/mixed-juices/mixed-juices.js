// @ts-check
//
// The line above enables type checking for this file. Various IDEs interpret
// the @ts-check directive. It will give you helpful autocompletion when
// implementing this exercise.

function countWedge(wedgeSize) {
	switch (wedgeSize) {
		case 'small':	return 6;
		case 'medium':	return 8;
		case 'large': return 10;
		default: throw new Error('Incorrect wedge size');
	}
}

/**
 * Determines how long it takes to prepare a certain juice.
 *
 * @param {string} name
 * @returns {number} time in minutes
 */
export function timeToMixJuice(name) {
	switch (name) {
		case 'Pure Strawberry Joy':
			return 0.5;
		case 'Energizer':
		case 'Green Garden':
			return 1.5;
		case 'Tropical Island':
			return 3;
		case 'All or Nothing':
			return 5;
		default:
			return 2.5;
	}
}

/**
 * Calculates the number of limes that need to be cut
 * to reach a certain supply.
 *
 * @param {number} wedgesNeeded
 * @param {string[]} limes
 * @returns {number} number of limes cut
 */
export function limesToCut(wedgesNeeded, limes) {
	let limeCount = 0;
	let wedgeCount = 0;

	while ((wedgesNeeded > wedgeCount) && (limes.length > limeCount)) {
		wedgeCount += countWedge(limes[limeCount++]);
		
	}

	return limeCount;
}

/**
 * Determines which juices still need to be prepared after the end of the shift.
 *
 * @param {number} timeLeft
 * @param {string[]} orders
 * @returns {string[]} remaining orders after the time is up
 */
export function remainingOrders(timeLeft, orders) {
	while (timeLeft > 0) timeLeft -= timeToMixJuice(orders.shift());
	
	return orders;
}

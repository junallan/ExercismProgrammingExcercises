// @ts-check
//
// The line above enables type checking for this file. Various IDEs interpret
// the @ts-check directive. It will give you helpful autocompletion when
// implementing this exercise.

const DAYS_IN_WEEK = 7;

function add(a, b) {
	return a + b;
}

/**
 * Calculates the total bird count.
 *
 * @param {number[]} birdsPerDay
 * @returns {number} total bird count
 */
export function totalBirdCount(birdsPerDay) {
	return birdsPerDay.reduce(add);
}

/**
 * Calculates the total number of birds seen in a specific week.
 *
 * @param {number[]} birdsPerDay
 * @param {number} week
 * @returns {number} birds counted in the given week
 */
export function birdsInWeek(birdsPerDay, week) {
	const startOfWeekIndex = (week-1) * DAYS_IN_WEEK;
	const birdsForTheWeek = birdsPerDay.slice(startOfWeekIndex, startOfWeekIndex + DAYS_IN_WEEK);

	return totalBirdCount(birdsForTheWeek);
}

/**
 * Fixes the counting mistake by increasing the bird count
 * by one for every second day.
 *
 * @param {number[]} birdsPerDay
 * @returns {number[]} corrected bird count data
 */
export function fixBirdCountLog(birdsPerDay) {
	for (let i = 0; i < birdsPerDay.length; i+=2) {
		birdsPerDay[i] += 1;
	}

	return birdsPerDay;
}

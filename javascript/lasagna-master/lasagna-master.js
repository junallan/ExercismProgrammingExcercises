/// <reference path="./global.d.ts" />
// @ts-check

const GRAMS_OF_NOODLES_PER_LAYER = 50;
const LITERS_OF_SAUCE_PER_LAYER = 0.2;

export function cookingStatus(remainingCookingTime) {
	switch (remainingCookingTime) {
		case undefined: return 'You forgot to set the timer.';
		case 0:			return 'Lasagna is done.';
		default:		return 'Not done, please wait.';
	}
}

export function preparationTime(layers, preparationTime=2) {
	return layers.length * preparationTime;
}

export function quantities(layers) {
	let noodleQuantity = 0;
	let sauceQuantity = 0;

	for (let i = 0; i < layers.length; i++) {
		if (layers[i] === 'sauce') sauceQuantity += LITERS_OF_SAUCE_PER_LAYER;
		else if (layers[i] === 'noodles') noodleQuantity += GRAMS_OF_NOODLES_PER_LAYER;
	}

	return { noodles: noodleQuantity, sauce: sauceQuantity};
}

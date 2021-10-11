/// <reference path="./global.d.ts" />
// @ts-check

export function cookingStatus(remainingCookingTime) {
	switch (remainingCookingTime) {
		case undefined: return 'You forgot to set the timer.';
		case 0: return 'Lasagna is done.';
		default: return 'Not done, please wait.';
	}
}

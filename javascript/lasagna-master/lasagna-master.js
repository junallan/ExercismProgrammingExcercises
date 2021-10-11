/// <reference path="./global.d.ts" />
// @ts-check

const GRAMS_OF_NOODLES_PER_LAYER = 50;
const LITERS_OF_SAUCE_PER_LAYER = 0.2;
const PORTIONS_FOR_RECIPE = 2;

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
	return layers.reduce((noodlesAndSauceAmount, ingredient) => {
							if (ingredient === 'noodles') noodlesAndSauceAmount.noodles += GRAMS_OF_NOODLES_PER_LAYER;
							if (ingredient === 'sauce') noodlesAndSauceAmount.sauce += LITERS_OF_SAUCE_PER_LAYER;

							return noodlesAndSauceAmount;
						}, { noodles: 0, sauce:0 });
}

export function addSecretIngredient(friendsList, myList) {
	myList.push(friendsList[friendsList.length - 1]);
}

export function scaleRecipe(recipe, portions=0) {
	const recipeScaleFactor = portions / PORTIONS_FOR_RECIPE;
	
	return Object.entries(recipe).reduce((recipeScaled, [ingredient, amount]) => {
				recipeScaled[ingredient] = amount * recipeScaleFactor;

				return recipeScaled;
		   }, { })
}

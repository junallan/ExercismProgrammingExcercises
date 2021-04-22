export const age = (planet, secondsTravelled) => {
	const planetSecondPeriods = {
		earth: 31557600,
		mercury: 7600543.82,
		venus: 19414149.05,
		mars: 59354032.69,
		jupiter: 374355659.1,
		saturn: 929292362.9,
		uranus: 2651370019,
		neptune: 5200418560
	};

	return Number((secondsTravelled / planetSecondPeriods[planet]).toFixed(2));

	//Variation 2
	//caluculation to deal with rare case of floating point precision in calculation being off, below calculation is more accurate
	//let round = (number, decimalPlaces) => Number(Math.round(number + 'e' + decimalPlaces) + 'e-' + decimalPlaces);

	//Variation 3
	//calculation not 100% accurate with all floating point numbers
	//const round = (number, decimalPlaces) => {
	//	const factorOfTen = Math.pow(10, decimalPlaces);
	//	return Math.round(number * factorOfTen) / factorOfTen;
	//};

	 //return round(secondsTravelled / planetSecondPeriods[planet], 2);
};

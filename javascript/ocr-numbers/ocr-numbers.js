export const convert = (input) => {
	if (input.trim() === '') return '';

	const parsedInput = input.split('\n');

	const firstLineNumberToProcess = parsedInput[0].substr(0, 3);
	const secondLineNumberToProcess = parsedInput[1].substr(0, 3);
	const thirdLineNumberToProcess = parsedInput[2].substr(0, 3);

	const nextNumberDataToProcess = parsedInput[0].length > 3 ? parsedInput[0].substr(3) + '\n' + parsedInput[1].substr(3) + '\n' + parsedInput[2].substr(3) + '\n' + '   ' : '';

	if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === '| |' && thirdLineNumberToProcess === '|_|') return '0' + convert(nextNumberDataToProcess);
	if (firstLineNumberToProcess === '   ' && secondLineNumberToProcess === '  |' && thirdLineNumberToProcess === '  |') return '1' + convert(nextNumberDataToProcess);
	if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === ' _|' && thirdLineNumberToProcess === '|_ ') return '2';
	if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === ' _|' && thirdLineNumberToProcess === ' _|') return '3';
	if (firstLineNumberToProcess === '   ' && secondLineNumberToProcess === '|_|' && thirdLineNumberToProcess === '  |') return '4';
	if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === '|_ ' && thirdLineNumberToProcess === ' _|') return '5';
	if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === '|_ ' && thirdLineNumberToProcess === '|_|') return '6'; 
	if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === '  |' && thirdLineNumberToProcess === '  |') return '7'; 	 
	if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === '|_|' && thirdLineNumberToProcess === '|_|') return '8';
	if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === '|_|' && thirdLineNumberToProcess === ' _|') return '9';	 

	return '?'
};

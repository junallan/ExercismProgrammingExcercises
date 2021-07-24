export const convert = (input) => {
	if (input.trim() === '') return '';

	const parsedInput = input.split('\n');

	const numbersToProcess = parsedInput[0].length / 3;
	let convertedNumbers = '';

	for (let i = 0; i < numbersToProcess; i++) {
		const startIndex = i * 3;
		const firstLineNumberToProcess = parsedInput[0].substr(startIndex, 3);
		const secondLineNumberToProcess = parsedInput[1].substr(startIndex, 3);
		const thirdLineNumberToProcess = parsedInput[2].substr(startIndex, 3);

		if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === '| |' && thirdLineNumberToProcess === '|_|') convertedNumbers += '0';
		else if (firstLineNumberToProcess === '   ' && secondLineNumberToProcess === '  |' && thirdLineNumberToProcess === '  |') convertedNumbers += '1';
		else if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === ' _|' && thirdLineNumberToProcess === '|_ ') convertedNumbers += '2';
		else if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === ' _|' && thirdLineNumberToProcess === ' _|') convertedNumbers += '3';
		else if (firstLineNumberToProcess === '   ' && secondLineNumberToProcess === '|_|' && thirdLineNumberToProcess === '  |') convertedNumbers += '4';
		else if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === '|_ ' && thirdLineNumberToProcess === ' _|') convertedNumbers += '5';
		else if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === '|_ ' && thirdLineNumberToProcess === '|_|') convertedNumbers += '6';
		else if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === '  |' && thirdLineNumberToProcess === '  |') convertedNumbers += '7';
		else if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === '|_|' && thirdLineNumberToProcess === '|_|') convertedNumbers += '8';
		else if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === '|_|' && thirdLineNumberToProcess === ' _|') convertedNumbers += '9';
		else convertedNumbers += '?';	
	}

	const nextGroupOfNumbers = parsedInput.length / 4;

	if (nextGroupOfNumbers > 1) convertedNumbers += ',';


	let nextNumberDataToProcess = '';

	for (let i = 1; i < nextGroupOfNumbers; i++) {
		const nextNumberSetStart = i * 4;
		nextNumberDataToProcess += parsedInput[nextNumberSetStart] + '\n' + parsedInput[nextNumberSetStart + 1] + '\n' + parsedInput[nextNumberSetStart + 2] + '\n' + parsedInput[nextNumberSetStart + 3] + '\n';
	}
	if (nextNumberDataToProcess.endsWith('\n')) nextNumberDataToProcess = nextNumberDataToProcess.slice(0,-1);

	return convertedNumbers + convert(nextNumberDataToProcess);
}; 
export const convert = (input) => {
	if (input.trim() === '') return '';

	const ColumnsPerInput = 3;
	const parsedInput = input.split('\n');

	const NumbersToProcess = parsedInput[0].length / ColumnsPerInput;
	let convertedNumbers = '';

	for (let i = 0; i < NumbersToProcess; i++) {
		const startIndex = i * ColumnsPerInput;
		const firstLineNumberToProcess = parsedInput[0].substr(startIndex, ColumnsPerInput);
		const secondLineNumberToProcess = parsedInput[1].substr(startIndex, ColumnsPerInput);
		const thirdLineNumberToProcess = parsedInput[2].substr(startIndex, ColumnsPerInput);

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

	const LinesPerParsedInput = 4;
	const nextGroupOfNumbers = parsedInput.length / LinesPerParsedInput;

	if (nextGroupOfNumbers > 1) convertedNumbers += ',';


	let nextNumberDataToProcess = '';

	for (let i = 1; i < nextGroupOfNumbers; i++) {
		const nextNumberSetStartIndex = i * LinesPerParsedInput;
		nextNumberDataToProcess += parsedInput[nextNumberSetStartIndex] + '\n' + parsedInput[nextNumberSetStartIndex + 1] + '\n' + parsedInput[nextNumberSetStartIndex + 2] + '\n' + parsedInput[nextNumberSetStartIndex + 3] + '\n';
	}
	if (nextNumberDataToProcess.endsWith('\n')) nextNumberDataToProcess = nextNumberDataToProcess.slice(0,-1);

	return convertedNumbers + convert(nextNumberDataToProcess);
}; 
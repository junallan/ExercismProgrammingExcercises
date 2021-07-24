export const convert = (input) => {
	if (input.trim() === '') return '';

	const ColumnsPerInput = 3;
	const parsedInput = input.split('\n');

	const NumbersToProcess = parsedInput[0].length / ColumnsPerInput;
	let convertedNumbers = '';

	for (let i = 0; i < NumbersToProcess; i++) {
		const startIndex = i * ColumnsPerInput;

		convertedNumbers += ProcessNumber(parsedInput[0].substr(startIndex, ColumnsPerInput),
									      parsedInput[1].substr(startIndex, ColumnsPerInput),
 										  parsedInput[2].substr(startIndex, ColumnsPerInput));
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

function ProcessNumber(firstLineNumberToProcess, secondLineNumberToProcess, thirdLineNumberToProcess) {
	if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === '| |' && thirdLineNumberToProcess === '|_|') return '0';
	if (firstLineNumberToProcess === '   ' && secondLineNumberToProcess === '  |' && thirdLineNumberToProcess === '  |') return '1';
	if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === ' _|' && thirdLineNumberToProcess === '|_ ') return '2';
	if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === ' _|' && thirdLineNumberToProcess === ' _|') return '3';
	if (firstLineNumberToProcess === '   ' && secondLineNumberToProcess === '|_|' && thirdLineNumberToProcess === '  |') return '4';
	if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === '|_ ' && thirdLineNumberToProcess === ' _|') return '5';
	if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === '|_ ' && thirdLineNumberToProcess === '|_|') return '6';
	if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === '  |' && thirdLineNumberToProcess === '  |') return '7';
	if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === '|_|' && thirdLineNumberToProcess === '|_|') return '8';
	if (firstLineNumberToProcess === ' _ ' && secondLineNumberToProcess === '|_|' && thirdLineNumberToProcess === ' _|') return '9';
	return '?';	
}

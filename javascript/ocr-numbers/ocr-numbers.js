export const convert = (input) => {
	if (input.trim() === '') return '';

	const parsedInput = input.split('\n');

	const LinesPerParsedInput = 4;
	const NextGroupOfNumbers = parsedInput.length / LinesPerParsedInput;

	let nextNumberDataToProcess = [...Array(NextGroupOfNumbers-1).keys()].reduce((accummulator, _, i) => {
																				const LinesPerParsedInput = 4;
																				const nextNumberSetStartIndex = (i+1) * LinesPerParsedInput;
			
																				return accummulator + parsedInput[nextNumberSetStartIndex] + '\n' + parsedInput[nextNumberSetStartIndex + 1] + '\n' + parsedInput[nextNumberSetStartIndex + 2] + '\n' + parsedInput[nextNumberSetStartIndex + 3] + '\n';
																				}, '');

	if (nextNumberDataToProcess.endsWith('\n')) nextNumberDataToProcess = nextNumberDataToProcess.slice(0,-1);

	return NumberRepresentationOfData(parsedInput, NextGroupOfNumbers > 1) + convert(nextNumberDataToProcess);
}; 

function NumberRepresentationOfData(parsedInput, hasNextGroupOfNumbers) {
	const ColumnsPerInput = 3;
	const NumbersToProcess = parsedInput[0].length / ColumnsPerInput;

	let convertedNumbers = [...Array(NumbersToProcess).keys()].reduce((accumulator, _, i) => {
		const ColumnsPerInput = 3;
		const startIndex = i * ColumnsPerInput;

		return accumulator + ProcessNumber(parsedInput[0].substr(startIndex, ColumnsPerInput),
			parsedInput[1].substr(startIndex, ColumnsPerInput),
			parsedInput[2].substr(startIndex, ColumnsPerInput));
	}, '');

	if (hasNextGroupOfNumbers) convertedNumbers += ',';

	return convertedNumbers;
}

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

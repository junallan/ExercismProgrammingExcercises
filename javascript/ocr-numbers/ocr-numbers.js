export const convert = (input) => {
	const parsedInput = input.split('\n');

	if (parsedInput[0] === ' _ ' && parsedInput[1] === '| |' && parsedInput[2] === '|_|') return '0';
	if (parsedInput[0] === '   ' && parsedInput[1] === '  |' && parsedInput[2] === '  |') return '1';
	if (parsedInput[0] === ' _ ' && parsedInput[1] === ' _|' && parsedInput[2] === '|_ ') return '2';
	if (parsedInput[0] === ' _ ' && parsedInput[1] === ' _|' && parsedInput[2] === ' _|') return '3';
	if (parsedInput[0] === '   ' && parsedInput[1] === '|_|' && parsedInput[2] === '  |') return '4';
	if (parsedInput[0] === ' _ ' && parsedInput[1] === '|_ ' && parsedInput[2] === ' _|') return '5';
	 
		 
		 
		 	 
		
};

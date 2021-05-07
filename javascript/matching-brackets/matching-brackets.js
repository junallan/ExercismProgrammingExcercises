export const isPaired = (data) => {
	const regex = new RegExp(/\[.*\]|{.*}|\(*.\)/);
	let bracketsFound = data.match(/[\[\]{})(]/g);

	if (bracketsFound === null) { return true; }

	if (bracketsFound.length % 2 !== 0) { return false; }

	let matchingEndBraceIndex = bracketsFound.length - 1;
	let halfOfBracketsCount = bracketsFound.length;

	//console.log(bracketsFound.join(''));
	//console.log(bracketsFound.join('').replace(/\[\]|{}|\(\)/g, ''));

	for (let i = 0; i < halfOfBracketsCount; i++) {
		if (bracketsFound[i] === '{' && (bracketsFound[i + 1] !== '}' && bracketsFound[matchingEndBraceIndex] !== '}')) {			
			return false;
		} else if (bracketsFound[i] === '[' && (bracketsFound[i + 1] !== ']' && bracketsFound[matchingEndBraceIndex] !== ']')) {
			return false;
		} else if (bracketsFound[i] === '(' && (bracketsFound[i + 1] !== ')' && bracketsFound[matchingEndBraceIndex] !== ')')) {
			return false;
		}

		if (i !== bracketsFound.length - 1) {
			if (bracketsFound[i] === '{' && bracketsFound[i + 1] === '}') {
				continue;
			}
			else if (bracketsFound[i] === '[' && bracketsFound[i + 1] === ']') {
				continue;
			}
			else if (bracketsFound[i] === '(' && bracketsFound[i + 1] === ')') {
				continue;
			}
		}

		if (i !== 0) {
			if (bracketsFound[i - 1] === '{' && bracketsFound[i] === '}') {
				continue;
			}
			else if (bracketsFound[i - 1] === '[' && bracketsFound[i] === ']') {
				continue;
			}
			else if (bracketsFound[i - 1] === '(' && bracketsFound[i] === ')') {
				continue;
			}
		}

		matchingEndBraceIndex--;
	}

	return regex.test(data);
};

export const isPaired = (data) => {
	/*if (data.length === 0) { return true; }*/
	//const regex = new RegExp(/\[.*\]|{.*}|(.*)/);
	const regex = new RegExp(/\[.*\]|{.*}|\(*.\)/);

	let bracketsFound = data.match(/[\[\]{})(]/g);
	//console.log(bracketsFound);
	if (bracketsFound === null) { return true; }

	for (let i = 0; i < bracketsFound.length; i++) {
		if (bracketsFound[i] === '{') {
			if (!bracketsFound.includes('}')) { return false; }
		} else if (bracketsFound[i] === '[') {
			if (!bracketsFound.includes(']')) { return false; }
		} else if (bracketsFound[i] === '(') {
			if (!bracketsFound.includes(')')) { return false; }
		} else if (bracketsFound[i] === '}') {
			if (!bracketsFound.includes('{')) { return false; }
		} else if (bracketsFound[i] === ']') {
			if (!bracketsFound.includes('[')) { return false; }
		} else if (bracketsFound[i] === ')') {
			if (!bracketsFound.includes('(')) { return false; }
		}
	}

	return regex.test(data);
};

const symbolMapping = {
	I:1,
	V:5,
	X: 10,
	L: 50,
	C: 100,
	D: 500,
	M: 1000
};

export const toRoman = (number) => {
	if (number === 0) {
		return '';
	}
	else if (number < symbolMapping.V - symbolMapping.I) {
		return 'I'.repeat(number);
	}
	else if (number === symbolMapping.V - symbolMapping.I) {
		return 'IV'
	}
	else if (number < symbolMapping.X - symbolMapping.I) {
		return `V${'I'.repeat(number - symbolMapping.V)}`;
	}
	else if (number === symbolMapping.X - symbolMapping.I) {
		return 'IX';
	}
	else if (number < symbolMapping.L- symbolMapping.X) {
		return `X${toRoman(number - symbolMapping.X)}`;
	}
	else if (number < symbolMapping.L) {
		return `XL${toRoman(number - (symbolMapping.L - symbolMapping.X))}`;
	}
	else if (number < symbolMapping.C - symbolMapping.X) {
		return `L${toRoman(number - symbolMapping.L)}`;
	}
	else if (number < symbolMapping.C) {
		return `XC${toRoman(number - (symbolMapping.C - symbolMapping.X))}`;
	}
	else if (number < symbolMapping.D - symbolMapping.C) {
		return `C${toRoman(number - symbolMapping.C)}`;
	}
	else if (number < symbolMapping.D) {
		return `CD${toRoman(number - (symbolMapping.D - symbolMapping.C))}`;
	}
	else if (number < symbolMapping.M - symbolMapping.C) {
		return `D${toRoman(number - symbolMapping.D)}`;
	}
	else if (number < symbolMapping.M) {
		return `CM${toRoman(number - (symbolMapping.M - symbolMapping.C))}`;
	}
	else {
		return `M${toRoman(number - symbolMapping.M)}`;
	}
};


 
export const encode = (value) => {
	let encodedValue = '';
	let previousValue = ''; 
	let repeatedValueCount = 0;

	[...value].forEach(function (element) {
		if (previousValue !== '') {
			if (element === previousValue) {
				repeatedValueCount++;
			}
			else {
				if (repeatedValueCount === 0) {
					encodedValue += previousValue;
				}
				else {
					encodedValue += (++repeatedValueCount).toString() + previousValue;
					repeatedValueCount = 0;
				}			
			}
		}	

		previousValue = element;
	});

	if (repeatedValueCount > 0) {
		encodedValue += (++repeatedValueCount).toString() + previousValue;
	}
	else {
		encodedValue += previousValue;
	}

	return encodedValue;
};


export const decode = (value) => {
	let valueParsed = value.split(/(\d+)/).filter(x => x.length > 0);

	let decodedValue = '';
	let i = 0;
	
	while (i < valueParsed.length) {
		if (!isNaN(valueParsed[i])) {
			if (valueParsed[i + 1].length == 1) {
				decodedValue += valueParsed[i + 1].repeat(valueParsed[i]);			
			}
			else {
				decodedValue += valueParsed[i + 1][0].repeat(valueParsed[i]);
				let otherElements = valueParsed[i + 1].substring(1, valueParsed[i + 1].length);
				[...otherElements].forEach(function (element) {
					decodedValue += element;
				});
			}

			i += 2;
		}
		else {
			decodedValue += valueParsed[i];
			i++;
		}		
	}

	return decodedValue;
};

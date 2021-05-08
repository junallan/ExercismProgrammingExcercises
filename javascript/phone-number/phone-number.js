export const clean = (phoneNumber) => {
	if (/[a-z]/i.test(phoneNumber)) { throw Error('Letters not permitted'); }
	if (/[@:!]/.test(phoneNumber)) { throw Error('Punctuations not permitted'); }

	let phoneNumberParsed = phoneNumber.replace(/[^\d]/g, "");

	if (phoneNumberParsed.length < 10) {
		throw Error('Incorrect number of digits');
	}

	if (phoneNumberParsed.length > 11) {
		throw Error('More than 11 digits')
	}

	if (phoneNumberParsed.length === 11) {
		if (/^[^1]/.test(phoneNumberParsed)) { throw Error('11 digits must start with 1'); }
	
		validateAreaCode(phoneNumberParsed.substring(1));
		validateExchangeCode(phoneNumberParsed.substring(1));

		return phoneNumberParsed.replace(/^\d/, "");
	}

	validateAreaCode(phoneNumberParsed);
	validateExchangeCode(phoneNumberParsed);

	return phoneNumberParsed;
};

function validateAreaCode(phoneNumberParsed) {
	if (/^0/.test(phoneNumberParsed)) { throw Error('Area code cannot start with zero'); }
	if (/^1/.test(phoneNumberParsed)) { throw Error('Area code cannot start with one'); }
}

function validateExchangeCode(phoneNumberParsed) {
	if (/^\d{3}0/.test(phoneNumberParsed)) { throw Error('Exchange code cannot start with zero'); }
	if (/^\d{3}1/.test(phoneNumberParsed)) { throw Error('Exchange code cannot start with one'); }
}

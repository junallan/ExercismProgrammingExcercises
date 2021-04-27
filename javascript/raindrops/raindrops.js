export const convert = (number) => {
	const sounds = { 3: 'Pling' , 5: 'Plang' , 7: 'Plong' };

	let response = "";

	Object.keys(sounds).forEach(function (key) {
		if (number % key === 0) {
			response += sounds[key];
		}
	});

	return response.length === 0 ? number.toString() : response;
};

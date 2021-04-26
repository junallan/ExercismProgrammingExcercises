export const transform = (data) => {
	let dataMap = new Map(Object.entries(data));
	let transformedMap = new Map();

	dataMap.forEach((item, key) => {
		for (let i = 0; i < item.length; i++) {
			transformedMap.set(new String(item[i]).toLowerCase(), parseInt(key));
		}
	});

	return Object.fromEntries(transformedMap);
};

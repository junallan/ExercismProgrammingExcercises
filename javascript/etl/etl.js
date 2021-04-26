export const transform = (data) => {
	let dataMap = new Map(Object.entries(data));
	let transformedMap = new Map();

	dataMap.forEach((items, key) => {
		for (let i = 0; i < items.length; i++) {
			transformedMap.set(new String(items[i]).toLowerCase(), parseInt(key));
		}
	});

	return Object.fromEntries(transformedMap);
};

export const transform = (data) => {
	let dataMap = new Map(Object.entries(data));
	let transformedMap = {};

	dataMap.forEach((items, key) => {
		for (let i = 0; i < items.length; i++) {
			transformedMap[new String(items[i]).toLowerCase()] = parseInt(key);
		}
	});

	return transformedMap;
};

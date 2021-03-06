export const encode = (value) => {
	return value.replace(/(.)\1*/g, (match, repeatValue) => match.length === 1 ? repeatValue : match.length + repeatValue);
};


export const decode = (value) => {
	return value.replace(/(\d+)(.)/g, (_, count, data) => count === 1 ? data : data.repeat(count));
};

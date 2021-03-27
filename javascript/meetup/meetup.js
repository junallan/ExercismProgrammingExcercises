export const meetup = (year, month, descriptor, dayOfWeek) => {
	let dayMapping = { Sunday: 0, Monday: 1, Tuesday: 2, Wednesday: 3, Thursday: 4, Friday: 5, Saturday: 6 };
	let weekMapping = { first: 0, second: 1, third: 2, fourth: 3 };

	let dayParsed = dayMapping[dayOfWeek];
	let daysInCurrentMonth = daysInMonth(year, month);
	let teenth = [13, 14, 15, 16, 17, 18, 19];
	
	let dateFound = null;

	if (descriptor === "teenth") {
		let teenthDateDay = teenth.filter(day => new Date(year, month - 1, day).getDay() === dayParsed);

		dateFound = new Date(year, month - 1, teenthDateDay[0]);
	}
	else {
		let dateDays = [...Array(daysInCurrentMonth).keys()].map(x => x + 1).filter(day => new Date(year, month - 1, day).getDay() === dayParsed);
		
		dateFound = descriptor === "last" ? new Date(year, month - 1, dateDays[dateDays.length - 1]) : new Date(year, month - 1, dateDays[weekMapping[descriptor]]);;	
	}

	return dateFound;
};

function daysInMonth(year, month) {
	return new Date(year, month, 0).getDate();
}

const isDivisibleBy = (year, n) => (year % n) === 0;

export const isLeap = (year) => isDivisibleBy(year, 4) ? !isDivisibleBy(year, 100) || isDivisibleBy(year, 400) ? true : false : false;

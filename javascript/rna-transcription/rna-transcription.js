export const toRna = (strand) => {
	let dnaToRna = { G:'C', C:'G', T:'A', A:'U' };

	return [...strand].map(s => dnaToRna[s]).join("");
};

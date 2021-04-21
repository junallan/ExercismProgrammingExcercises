export const toRna = (strand) => {
	const dnaToRna = { G:'C', C:'G', T:'A', A:'U' };

	return [...strand].map(nucleotide => dnaToRna[nucleotide]).join("");
};

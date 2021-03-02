export const translate = (codons) => {
	if (!codons) { return []; }

	let protein = [];

	let parsedCodons = codons.match(/.{1,3}/g);

	for (let i = 0; i < parsedCodons.length; i++) {
		switch (parsedCodons[i]) {
			case 'AUG':
				protein.push('Methionine');
				break;
			case 'UUU':
			case 'UUC':
				protein.push('Phenylalanine');
				break;
			case 'UUA':
			case 'UUG':
				protein.push('Leucine');
				break;
			case 'UCU':
			case 'UCC':
			case 'UCA':
			case 'UCG':
				protein.push('Serine');
				break;
			case 'UAU':
			case 'UAC':
				protein.push('Tyrosine');
				break;
			case 'UGU':
			case 'UGC':
				protein.push('Cysteine');
				break;
			case 'UGG':
				protein.push('Tryptophan');
				break;
			case 'UAA':
			case 'UAG':
			case 'UGA':
				return protein
			default:
				throw 'Invalid codon';
		}		
	}
	
	return protein;
};

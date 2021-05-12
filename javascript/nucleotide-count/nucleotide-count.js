export class NucleotideCounts {
    static parse(strand) {
        if (/[^ACGT]/g.test(strand)) { throw Error('Invalid nucleotide in strand'); }

        let strandCount = (nucleotide) => {
            let expression = new RegExp(`[${nucleotide}]`, 'g');
            let strandMatches = strand.match(expression);

            return strandMatches === null ? 0 : strandMatches.length;
        }

        return `${strandCount('A')} ${strandCount('C')} ${strandCount('G')} ${strandCount('T')}`;
    }
}



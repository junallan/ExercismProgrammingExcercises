export class NucleotideCounts {
    static parse(strand) {
        this.strand = strand;

        if (/[^ACGT]/g.test(strand)) { throw Error('Invalid nucleotide in strand'); }

      return `${this.strandCount('A')} ${this.strandCount('C')} ${this.strandCount('G')} ${this.strandCount('T')}`;
    }

    static strandCount(nucleotide) {
        let expression = new RegExp(`[${nucleotide}]`, 'g');
        let strandMatches = this.strand.match(expression);

        return strandMatches === null ? 0 : strandMatches.length;
    }
}



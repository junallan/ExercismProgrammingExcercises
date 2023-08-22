export class Anagram {
  private readonly _input: string;
  private readonly _sortedInput: string;

  constructor(input: string) {
    this._input = input.toLowerCase();
    this._sortedInput = this.sortString(this._input);
  }

  private sortString(str: string): string {
    return str.split('').sort().join('');
  }

  public matches(...potentials: string[]): string[] {   
    return potentials.filter(p =>
      this._input !== p.toLowerCase() &&
      this._sortedInput === this.sortString(p.toLowerCase())
    );
  }
}

export class Anagram {
  private _input: string = "";
  private _sortedInput: string = "";
  private _inputLength: number = 0;

  constructor(input: string) {
    this._input = input;
    this._sortedInput = this._input
    .split("")
    .sort()
    .join("");
    this._inputLength = this._input.length;
  }

  public matches(...potentials: string[]): string[] {   
    const anagramMatches: string[] = [];

    potentials.forEach(p => {
      if (this._input === p) { return; }
      if (this._inputLength !== p.length) { return; }
  
      const sortedPotential = p.split("")
        .sort()
        .join("");

      if (this._sortedInput !== sortedPotential) { return; }

      anagramMatches.push(p);

      console.log(sortedPotential);
    });

    return anagramMatches;
  }
}

export class Anagram {
  private readonly _input: string = "";
  private readonly _sortedInput: string = "";
  private readonly _inputLength: number = 0;

  constructor(input: string) {
    this._input = input;
    this._sortedInput = this.sortLowerCaseString(input);
    this._inputLength = this._input.length;
  }

  private sortLowerCaseString(str: string): string {
    return str.split("").sort().join("").toLowerCase();
  }

  public matches(...potentials: string[]): string[] {   
    const anagramMatches: string[] = [];

    return potentials.filter(p =>
      this._input !== p &&
      this._inputLength === p.length &&
      this._sortedInput == this.sortLowerCaseString(p)
    );

    // potentials.forEach(p => {
    //   if (this._input === p) { return; }
    //   if (this._inputLength !== p.length) { return; }
  
    //   const sortedPotential = p.split("")
    //     .sort()
    //     .join("");

    //   if (this._sortedInput !== sortedPotential) { return; }

    //   anagramMatches.push(p);

    //   console.log(sortedPotential);
    // });

    // return anagramMatches;
  }
}

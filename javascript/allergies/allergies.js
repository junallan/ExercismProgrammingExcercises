export class Allergies {
  constructor(inputData) {
      this._inputData = inputData;

      this._allergyMapping = {
          eggs: 1,
          peanuts: 2,
          shellfish: 4,
          strawberries: 8,
          tomatoes: 16,
          chocolate: 32,
          pollen: 64,
          cats: 128
      };

      let allergyNames = Reflect.ownKeys(this._allergyMapping);

      this._allergyList = [];

      for (let i = 0; i < allergyNames.length; i++) {
          if (this.allergicTo(allergyNames[i])) {
              this._allergyList.push(allergyNames[i]);
          }
      } 
  }

  list() {
      return this._allergyList;
  }

  allergicTo(alergy) {
      return (this._allergyMapping[alergy] & this._inputData) > 0;
  }
}

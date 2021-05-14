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
  }

  list() {
      let allergyNames = Reflect.ownKeys(this._allergyMapping);

      let allergyList = [];

      for (let i = 0; i < allergyNames.length; i++) {
          if (this.allergicTo(allergyNames[i])){
              allergyList.push(allergyNames[i]);
          }
      }

      return allergyList;
  }

  allergicTo(alergy) {
      return (this._allergyMapping[alergy] & this._inputData) > 0;
  }
}

export class RotationalCipher {
    static rotate(data, shiftPosition) {
        return new RotationalCipher(data).rotate(shiftPosition);
    }

    constructor(data) {
        this.data = data;
        this.ACharacterCode = 97;
        this.Alphabet = "abcdefghijklmnopqrstuvwxyz";
    }

    rotate(shiftPosition) {
        return this.data.replace(/[a-z]/gi, (characterMatch) => this.doShift(characterMatch, shiftPosition));
    }

    doShift(character, shiftPosition) {
        const lowerCaseLetter = this.getLetterRotation(character.toLowerCase(), shiftPosition);
        const isCharacterLowercase = character.toLowerCase() === character;

        return isCharacterLowercase ? lowerCaseLetter : lowerCaseLetter.toUpperCase();
    }

    indexOf(character) {
        return character.charCodeAt(0) - this.ACharacterCode;
    }

    getLetterRotation(character, shiftPosition) {
        const elementPosition = (this.indexOf(character) + shiftPosition) % this.Alphabet.length

        return this.Alphabet.charAt(elementPosition);
    }
   
}


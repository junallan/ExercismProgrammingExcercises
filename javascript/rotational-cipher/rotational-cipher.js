export class RotationalCipher {
    static ASCIICharacterCodeOfa = 97;
    static Alphabet = "abcdefghijklmnopqrstuvwxyz";

    constructor(data) { this.data = data; }

    static rotate(data, shiftPosition) { return new RotationalCipher(data).rotate(shiftPosition); }
    rotate(shiftPosition) { return this.data.replace(/[a-z]/gi, (characterMatch) => this.doShift(characterMatch, shiftPosition)); }
    
    doShift(character, shiftPosition) {
        const lowerCaseLetter = this.getLetterRotation(character.toLowerCase(), shiftPosition);
        const isCharacterLowercase = character.toLowerCase() === character;

        return isCharacterLowercase ? lowerCaseLetter : lowerCaseLetter.toUpperCase();
    }

    getLetterRotation(character, shiftPosition) {
        const elementPosition = (this.indexOf(character) + shiftPosition) % RotationalCipher.Alphabet.length

        return RotationalCipher.Alphabet.charAt(elementPosition);
    }

    indexOf(character) { return character.charCodeAt(0) - RotationalCipher.ASCIICharacterCodeOfa; }
}


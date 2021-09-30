export class RotationalCipher {
    static rotate(data, shiftPosition) {
        return [...data].map(c => this.doShift(c,shiftPosition)).join('');
    }

    static doShift(character, shiftPosition) {
        if (!this.isCharacterALetter(character)) return character;

        const lowerCaseLetter = this.getLetterRotation(character.toLowerCase(), shiftPosition);      
        const isCharacterLowercase = character.toLowerCase() === character;

        return isCharacterLowercase ? lowerCaseLetter : lowerCaseLetter.toUpperCase();
    }

    static isCharacterALetter(char) {
        return char.toLowerCase() !== char.toUpperCase()
    }
    
    static getLetterRotation(dataElement, shiftPosition) {
        const alphabet = "abcdefghijklmnopqrstuvwxyz";
   
        const elementPosition = (alphabet.indexOf(dataElement) + shiftPosition) % alphabet.length
      
        return alphabet.charAt(elementPosition);
    }
}


export class RotationalCipher {
    static rotate(data, shiftPosition) {
        return data.replace(/[a-z]/gi, (characterMatch) => {
            return this.doShift(characterMatch, shiftPosition);
        });
    }

    static doShift(character, shiftPosition) {
        const lowerCaseLetter = this.getLetterRotation(character.toLowerCase(), shiftPosition);      
        const isCharacterLowercase = character.toLowerCase() === character;

        return isCharacterLowercase ? lowerCaseLetter : lowerCaseLetter.toUpperCase();
    }
    
    static getLetterRotation(dataElement, shiftPosition) {
        const alphabet = "abcdefghijklmnopqrstuvwxyz";
   
        const elementPosition = (alphabet.indexOf(dataElement) + shiftPosition) % alphabet.length
      
        return alphabet.charAt(elementPosition);
    }
}


export class RotationalCipher {
    static rotate(data, shiftPosition) {
        return data.replace(/[a-z]/gi, (characterMatch) =>  this.doShift(characterMatch, shiftPosition) );
    }

    static doShift(character, shiftPosition) {
        const lowerCaseLetter = this.getLetterRotation(character.toLowerCase(), shiftPosition);      
        const isCharacterLowercase = character.toLowerCase() === character;

        return isCharacterLowercase ? lowerCaseLetter : lowerCaseLetter.toUpperCase();
    }

    static indexOf(character) {
        const aCharacterCode = 97;
        return character.charCodeAt(0) - aCharacterCode;
    }
    
    static getLetterRotation(character, shiftPosition) {
        const alphabet = "abcdefghijklmnopqrstuvwxyz";
   
        const elementPosition = (this.indexOf(character) + shiftPosition) % alphabet.length
      
        return alphabet.charAt(elementPosition);
    }
}


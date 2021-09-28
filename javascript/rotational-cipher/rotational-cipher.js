export class RotationalCipher {
    static rotate(data, key) {
        return [...data].map(d => this.doRotation(d, key)).join('');
    }

    static doRotation(data, key) {
        if (!this.isCharacterALetter(data)) return data;

        const lowerCaseLetterCode = data.toLowerCase().charCodeAt(0);
        
        const letterRotationCode = this.getLetterRotationCode(lowerCaseLetterCode, key);
           
        const isCharacterLowercase = data.toLowerCase() === data;
        const lowerCaseLetter = String.fromCharCode(letterRotationCode);

        return isCharacterLowercase ? lowerCaseLetter : lowerCaseLetter.toUpperCase();
    }

    static isCharacterALetter(char) {
        return char.toLowerCase() !== char.toUpperCase()
    }

    static getLetterRotationCode(elementCode, key) {
        const zCharCode = 122;
        const alphabetBoundary = 25;
        const letterRotationCode = elementCode + key;
        const aCharCode = zCharCode - alphabetBoundary;

        return ((elementCode - aCharCode) + key) <= (zCharCode - aCharCode) ? letterRotationCode : (letterRotationCode % zCharCode) + (aCharCode - 1);
    }
}


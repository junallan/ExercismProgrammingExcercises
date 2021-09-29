export class RotationalCipher {
    static rotate(data, shiftPosition) {
        return [...data].map(d => this.doShift(d, shiftPosition)).join('');
    }

    static doShift(data, shiftPosition) {
        if (!this.isCharacterALetter(data)) return data;

        const letterRotationCode = this.getLetterRotationCode(data.toLowerCase().charCodeAt(0), shiftPosition);      
        const lowerCaseLetter = String.fromCharCode(letterRotationCode);

        return data.toLowerCase() === data ? lowerCaseLetter : lowerCaseLetter.toUpperCase();
    }

    static isCharacterALetter(char) {
        return char.toLowerCase() !== char.toUpperCase()
    }

    static getLetterRotationCode(elementCode, shiftPosition) {
        const zCharCode = 122;
        const alphabetBoundary = 25;
        const aCharCode = zCharCode - alphabetBoundary;
        const letterRotationCode = elementCode + shiftPosition;

        return ((elementCode - aCharCode) + shiftPosition) <= (zCharCode - aCharCode) ? letterRotationCode : (letterRotationCode % zCharCode) + (aCharCode - 1);
    }
}


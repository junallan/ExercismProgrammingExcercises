export class RotationalCipher {
    static rotate(data, shiftPosition) {
        let dataTransformation = '';
        for (let i = 0; i < data.length; i++) {

           dataTransformation += this.doShift(data.charAt(i), shiftPosition);
        }

        return dataTransformation;
    }

    static doShift(dataElement, shiftPosition) {
        if (!this.isCharacterALetter(dataElement)) return dataElement;

        const letterRotationCode = this.getLetterRotationCode(dataElement.toLowerCase().charCodeAt(0), shiftPosition);      
        const lowerCaseLetter = String.fromCharCode(letterRotationCode);

        return dataElement.toLowerCase() === dataElement ? lowerCaseLetter : lowerCaseLetter.toUpperCase();
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


export class RotationalCipher {
    static rotate(data, key) {
        return String.fromCharCode(...[...data].map(d => this.doRotation(d, key)));
    }

    static doRotation(data, key) {
        const alphapetBoundary = 25;
        const ZCharCode = 90;
        const zCharCode = 122;

        const elementCode = data.charCodeAt(0);

        if (!(this.isCharacterCodeRange(elementCode, ZCharCode - alphapetBoundary, ZCharCode)) && !(this.isCharacterCodeRange(elementCode, zCharCode-alphapetBoundary, zCharCode))) return elementCode;

        const upperBoundCharacterCode = elementCode <= ZCharCode ? ZCharCode : zCharCode;

        return this.getLetterRotationCode(elementCode, key, upperBoundCharacterCode, alphapetBoundary);  
    }

    static isCharacterCodeRange(elementCode, lowerBoundCharacterCode, upperBoundCharacterCode) {
        return lowerBoundCharacterCode <= elementCode && elementCode <= upperBoundCharacterCode;
    }

    static getLetterRotationCode(elementCode, key, upperBoundCharacter, alphabetBoundary) {
        const letterRotationCode = elementCode + key;
        const lowerBoundCharacter = upperBoundCharacter - alphabetBoundary;

        return ((elementCode - lowerBoundCharacter) + key) <= (upperBoundCharacter - lowerBoundCharacter) ? letterRotationCode : (letterRotationCode % upperBoundCharacter) + (lowerBoundCharacter - 1);
    }
}


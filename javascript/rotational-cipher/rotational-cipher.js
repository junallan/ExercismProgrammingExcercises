export class RotationalCipher {
    static rotate(data, key) {
        return String.fromCharCode(...[...data].map(d => this.doRotation(d, key)));
    }

    static doRotation(data, key) {
        const aCharCode = 97;
        const zCharCode = 122;
        const ACharCode = 65;
        const ZCharCode = 90;

        const elementCode = data.charCodeAt(0);

        if (this.isCharacterCodeRange(elementCode, aCharCode, zCharCode)) {
            return this.getLetterRotationCode(elementCode, key, aCharCode, zCharCode);
        }
        else if (this.isCharacterCodeRange(elementCode, ACharCode, ZCharCode)) {
            return this.getLetterRotationCode(elementCode, key, ACharCode, ZCharCode);
        }
        else {
            return elementCode;
        }
        
    }

    static isCharacterCodeRange(elementCode, lowerBoundCharacterCode, upperBoundCharacterCode) {
        return lowerBoundCharacterCode <= elementCode && elementCode <= upperBoundCharacterCode;
    }

    static getLetterRotationCode(elementCode, key, lowerBoundCharacter, upperBoundCharacter) {
        let letterRotationCode = elementCode + key;

        return ((elementCode - lowerBoundCharacter) + key) <= (upperBoundCharacter - lowerBoundCharacter) ? letterRotationCode : (letterRotationCode % upperBoundCharacter) + (lowerBoundCharacter - 1);
    }
}


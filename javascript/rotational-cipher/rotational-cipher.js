export class RotationalCipher {
    static rotate(data, key) {
        return [...data].map(d => this.doRotation(d, key)).join('');
    }

    static doRotation(data, key) {
        const aCharCode = 97;
        const zCharCode = 122;
        const ACharCode = 65;
        const ZCharCode = 90;

        const elementCode = data.charCodeAt(0);

        if (this.isCharacterCodeRange(elementCode, aCharCode, zCharCode)) {
            return this.getLetterRotation(elementCode, key, aCharCode, zCharCode);
        }
        else if (this.isCharacterCodeRange(elementCode, ACharCode, ZCharCode)) {
            return this.getLetterRotation(elementCode, key, ACharCode, ZCharCode);
        }
        else {
            return data;
        }
        
    }

    static isCharacterCodeRange(elementCode, lowerBoundCharacterCode, upperBoundCharacterCode) {
        return lowerBoundCharacterCode <= elementCode && elementCode <= upperBoundCharacterCode;
    }

    static getLetterRotation(elementCode, key, lowerBoundCharacter, upperBoundCharacter) {
        let letterRotationCode = elementCode + key;

        return String.fromCharCode(((elementCode - lowerBoundCharacter) + key) <= (upperBoundCharacter - lowerBoundCharacter) ? letterRotationCode : (letterRotationCode % upperBoundCharacter) + (lowerBoundCharacter - 1));
    }
}


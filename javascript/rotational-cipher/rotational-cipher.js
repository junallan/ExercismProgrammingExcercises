const aCharCode = 97;
const zCharCode = 122;
const ACharCode = 65;
const ZCharCode = 90;

//console.log('a'.charCodeAt(0)); -> 97
//console.log('z'.charCodeAt(0)); -> 122
//console.log('A'.charCodeAt(0)); -> 65
//console.log('Z'.charCodeAt(0)); -> 90

//String.fromCharCode(97, 122, 65, 90) -> azAZ

export class RotationalCipher {
    static rotate(data, key) {
        return [...data].map(d => this.doRotation(d, key)).join('');
    }

    static doRotation(data, key) {
        const elementCode = data.charCodeAt(0);
        if (this.isLowerCaseLetter(elementCode)) {
            return this.getLetterRotation(elementCode, key, aCharCode, zCharCode);
        }
        else if (this.isUpperCaseLetter(elementCode)) {
            return this.getLetterRotation(elementCode, key, ACharCode, ZCharCode);
        }
        else {
            return data;
        }
        
    }

    static isLowerCaseLetter(elementCode) {   
        return aCharCode <= elementCode && elementCode <= zCharCode;
    }

    static isUpperCaseLetter(elementCode) {
        return ACharCode <= elementCode && elementCode <= ZCharCode;
    }

    static getLetterRotation(elementCode, key, lowerBoundCharacter, upperBoundCharacter) {
        let letterRotationCode = elementCode + key;

        return String.fromCharCode(((elementCode - lowerBoundCharacter) + key) <= (upperBoundCharacter - lowerBoundCharacter) ? letterRotationCode : (letterRotationCode % upperBoundCharacter) + (lowerBoundCharacter - 1));
    }

    //static getLowerCaseLetterRotation(elementCode, key) {
    //    let letterRotationCode = elementCode + key;
       
    //    return String.fromCharCode(((elementCode - aCharCode) + key) <= (zCharCode - aCharCode) ? letterRotationCode : (letterRotationCode % zCharCode) + (aCharCode - 1));
    //}

    //static getUpperCaseLetterRotation(elementCode, key) {
    //    let letterRotationCode = elementCode + key;

    //    return String.fromCharCode(((elementCode - ACharCode) + key) <= (zCharCode - ACharCode) ? letterRotationCode : (letterRotationCode % ZCharCode) + (ACharCode - 1));
    //}
}


const aCharCode = 97;
const zCharCode = 122;

//console.log('a'.charCodeAt(0)); -> 97
//console.log('z'.charCodeAt(0)); -> 122
//console.log('A'.charCodeAt(0)); -> 65
//console.log('Z'.charCodeAt(0)); -> 90

//String.fromCharCode(97, 122, 65, 90) -> azAZ

export class RotationalCipher {
    static rotate(data, key) {
        return [...data].map(d => this.doRotation(d, key)).join();
    }

    static doRotation(data, key) {
        const elementCode = data.charCodeAt(0);
        if (this.isLowerCaseLetter(elementCode)) {
            return String.fromCharCode(key <= (zCharCode - aCharCode) ? elementCode + key : ((elementCode + key) % zCharCode) + (aCharCode - 1));
        }
        else {
            return "";
        }
        
    }

    static isLowerCaseLetter(elementCode) {   
        return aCharCode <= elementCode && elementCode <= zCharCode;
    }
}


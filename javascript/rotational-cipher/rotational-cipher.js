const alphabetMapping = {
    'a': 0,
    'b': 1,
    'c': 2,
    'd': 3,
    'e': 4,
    'f': 5,
    'g': 6,
    'h': 7,
    'i': 8,
    'j': 9,
    'k': 10,
    'l': 11,
    'm': 12,
    'n': 13,
    'o': 14,
    'p': 15,
    'q': 16,
    'r': 17,
    's': 18,
    't': 19,
    'u': 20,
    'v': 21,
    'w': 22,
    'x': 23,
    'y': 24,
    'z': 25
};

const aCharCode = 97;
const zCharCode = 122;

//console.log('a'.charCodeAt(0)); -> 97
//console.log('z'.charCodeAt(0)); -> 122
//console.log('A'.charCodeAt(0)); -> 65
//console.log('Z'.charCodeAt(0)); -> 90

//String.fromCharCode(97, 122, 65, 90) -> azAZ

export class RotationalCipher {
    static rotate(data, key) {
        //const alphabet = 'abcdefghijklmnopqrstuvwxyz';
        const numberOfAlphabetCharacters = Object.keys(alphabetMapping).length;

      

        return [...data].map(d => this.doRotation(d, key)
            
            //((d.charCodeAt(0) + key) + 122) % 122)

                                                                ).join();
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

    //static getKey(value) {
    //    return Object.keys(alphabetMapping).filter(k => alphabetMapping[k] === value);
    //}
}


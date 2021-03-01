export class Triangle {
    constructor(...sides) {
        if (sides.length !== 3) { throw 'Triangle requires 3 sides'; }

        this.side1 = sides[0];
        this.side2 = sides[1];
        this.side3 = sides[2];
    }
    
    isSidesEqual(sides) {
        let isEqualSides = sides.every(function (currentElement, index, array) {
            if (index == array.length - 1) { return true; }

            return currentElement === array[index + 1];
        });

        return sides.every(function (currentElement, index, array) {
            if (index == array.length - 1) { return true; }

            return currentElement === array[index + 1];
        });
    }

    isValidTriangle(sides) {
        return (!(this.isLengthOfTwoSidesLessThanThird(sides[0], sides[1], sides[2])
                    || this.isLengthOfTwoSidesLessThanThird(sides[0], sides[2], sides[1])
                    || this.isLengthOfTwoSidesLessThanThird(sides[1], sides[2], sides[0])))
                && (sides[0] > 0 && sides[1] > 0 && sides[2] > 0);
    }

    isLengthOfTwoSidesLessThanThird(side1, side2, sideToAccumulate) {
        return (side1 + side2 < sideToAccumulate);
    }

    get isEquilateral() {
        return this.isValidTriangle([this.side1, this.side2, this.side3]) && this.isSidesEqual([this.side1, this.side2, this.side3]);
    }

    get isIsosceles() {
        return (this.isValidTriangle([this.side1, this.side2, this.side3]) &&
                        (this.isSidesEqual([this.side1, this.side2])
                        || this.isSidesEqual([this.side1, this.side3])
                        || this.isSidesEqual([this.side2, this.side3])));
    }

    get isScalene() {
        return this.isValidTriangle([this.side1, this.side2, this.side3]) &&
            !this.isSidesEqual([this.side1, this.side2])
            && !this.isSidesEqual([this.side2, this.side3])
            && !this.isSidesEqual([this.side1, this.side3]);
    }
}

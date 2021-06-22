export class Zipper {
    constructor(focus, root, upper) {
        this._focus = focus;
        this._root = root;
        this._upper = upper || [];
    }

    static fromTree(focus) {
        let treeCopy = JSON.parse(JSON.stringify(focus));
        return new Zipper(treeCopy, treeCopy);
    }

    toTree() {
        return this._root;
    }

    value() {
        return this._focus.value;
    }

    left() {
        if (this._focus.left === null) { return null; }

        this._upper.push(this._focus);
        this._focus = this._focus.left;

        return new Zipper(this._focus, this._root, this._upper);
    }

    right() {
        if (this._focus.right === null) { return null; }

        this._upper.push(this._focus);
        this._focus = this._focus.right;

        return new Zipper(this._focus, this._root, this._upper);
    }

    up() {
        if (this._upper.length === 0) { return null; }
        this._focus = this._upper.pop();

        return new Zipper(this._focus, this._root, this._upper);
    }

    setValue(value) {
        this._focus.value = value;

        return new Zipper(this._focus, this._root, this._upper);
    }

    setLeft(branch) {
        this._focus.left = branch;

        return new Zipper(this._focus, this._root, this._upper);
    }

    setRight(branch) {
        this._focus.right = branch;

        return new Zipper(this._focus, this._root, this._upper);
    }
}

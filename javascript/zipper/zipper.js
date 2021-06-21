export class Zipper {
    constructor(focus, parent) {
        this._focus = focus;
        this._parent = parent || null;
    }

    static fromTree(focus) {
        let treeCopy = JSON.parse(JSON.stringify(focus));
        return new Zipper(treeCopy);
    }

    toTree() {
        return this._parent ? this._parent.toTree() : this._focus;
    }

    value() {
        return this._focus.value;
    }

    left() {
        return this._focus.left ? new Zipper(this._focus.left, this) : null;
    }

    right() {
        return this._focus.right ? new Zipper(this._focus.right, this) : null;
    }

    up() {
        return this._parent;
    }

    setValue(value) {
        this._focus.value = value;

        return new Zipper(this._focus, this._parent);
    }

    setLeft(branch) {
        this._focus.left = branch;

        return new Zipper(this._focus.left, this);
    }

    setRight(branch) {
        this._focus.right = branch;

        return new Zipper(this._focus.right, this);
    }
}

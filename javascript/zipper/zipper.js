import { traverse } from "@babel/core";

function copy(tree) {
    return tree && Object.assign({}, tree);
}

export class Zipper {
    constructor(focus, parent) {
        this._focus = focus;
        this._parent = parent || null;
    }

    static fromTree(focus) {
        return new Zipper(copy(focus));
    }

    toTree() {
        return this._parent ? this._parent.toTree() : this._focus;
    }

    value() {
        return this._focus.value;
    }

    left() {
        this._focus.left = copy(this._focus.left);
        let next = this._focus.left;

        return next ? new Zipper(next, this) : null;
    }

    right() {
        this._focus.right = copy(this._focus.right);
        let next = this._focus.right;

        return next ? new Zipper(next, this) : null;
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

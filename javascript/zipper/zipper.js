export class Zipper {
    constructor(tree, parent) {
        this._zipper = tree;
        this._parent = parent
    }

    static fromTree(tree) {
        return new Zipper(tree);
    }

    toTree() {
        return this._zipper;
    }

    value() {
        return this._zipper.value;
    }

    left() {
        if (this._zipper.left === null) { return null; }

        return new Zipper(this._zipper.left, this._zipper);
    }

    right() {
        return new Zipper(this._zipper.right, this._zipper);
    }

    up() {
        if (this._parent === undefined || this._parent === null) { return null; }
        console.log(this._parent);
        //if (this._parent._parent === null) { return null; }

      return new Zipper(this._parent, this._parent._parent);
  }

  setValue() {
    throw new Error('Remove this statement and implement this function');
  }

  setLeft() {
    throw new Error('Remove this statement and implement this function');
  }

  setRight() {
    throw new Error('Remove this statement and implement this function');
  }
}

export class Zipper {
  constructor(tree) {
      this._zipper = tree;
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

      return new Zipper(this._zipper.left);
  }

  right() {
      return new Zipper(this._zipper.right);
  }

  up() {
    throw new Error('Remove this statement and implement this function');
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

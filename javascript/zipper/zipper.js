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
    throw new Error('Remove this statement and implement this function');
  }

  left() {
    throw new Error('Remove this statement and implement this function');
  }

  right() {
    throw new Error('Remove this statement and implement this function');
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

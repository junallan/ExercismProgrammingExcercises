import { traverse } from "@babel/core";

export class Zipper {
    constructor(root, focus, parent) {
        this._root = root;
        this._focus = focus;
        this._parent = parent
    }

    static fromTree(root) {
        return new Zipper(root,root);
    }

    toTree() {
        //console.log(this.up().up()._tree.left());
        return this._root;
        ////TO DO: TRAVERSE TO GET PARENT NODE
        //let currentTree = this;
        //let parentTree = this.up();
        ////console.log(parentTree);
        ////var parent = this._parent;

        //while (parentTree !== null) {
           
        //    currentTree = parentTree;
        //    //console.log(parentTree._parent);
        //    //console.log(parentTree.left);
        //    //console.log(parentTree);
        //    parentTree = parentTree.up();
           
         
        //}
        ////console.log(currentTree._tree);
        //return currentTree._tree;
    }

    value() {
        //console.log(this._tree);
        return this._focus.value;
    }

    left() {
        //console.log(this._tree);
        if (this._focus.left === null) { return null; }
       
        return new Zipper(this._root, this._focus.left, this._focus);
    }

    right() {
        //console.log(this._tree);
        return new Zipper(this._root, this._focus.right, this._focus);
    }

    up() {
        if (this._parent === undefined || this._parent === null) { return null; }
        //console.log(this._parent);
        //if (this._parent._parent === null) { return null; }
        //console.log(this._parent);
        //console.log(this._parent._parent);
      return new Zipper(this._root, this._parent);
  }

  setValue(value) {
      this._focus.value = value;
      //TODO
      return new Zipper(this._root, this._focus, this._parent);
  }

    setLeft(branch) {
        console.log(this._focus);
        this._focus.left = branch;
        console.log(this._focus);

      return new Zipper(this._root, this._focus, this._parent);
  }

  setRight() {
    throw new Error('Remove this statement and implement this function');
  }
}

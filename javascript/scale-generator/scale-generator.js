export class Scale {
  constructor(tonic) {
      this._tonic = tonic;
      this._scale = ['A', 'A#', 'B', 'C', 'C#', 'D', 'D#', 'E', 'F', 'F#', 'G', 'G#'];
  }

  chromatic() {
      let tonicIndex = this._scale.findIndex((note) => note === this._tonic);
      let scaleSequence = [];

      for (let i = tonicIndex; i < this._scale.length; i++) {
          scaleSequence.push(this._scale[i]);
      }

      for (let i = 0; i < tonicIndex; i++) {
          scaleSequence.push(this._scale[i]);
      }

      return scaleSequence;
  }

  interval(intervals) {
    throw new Error('Remove this statement and implement this function');
  }
}

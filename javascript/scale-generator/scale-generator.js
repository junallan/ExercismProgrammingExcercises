export class Scale {
  constructor(tonic) {
      this._tonic = tonic;
      this._scaleSharp = ['A', 'A#', 'B', 'C', 'C#', 'D', 'D#', 'E', 'F', 'F#', 'G', 'G#'];
      this._scaleFlat = ['A', 'Bb', 'B', 'C', 'Db', 'D', 'Eb', 'E', 'F', 'Gb', 'G', 'Ab'];
  }

  chromatic() {
      let flatNotes = ['F', 'Bb', 'Eb', 'Ab', 'Db', 'Gb','d','g','c','f','bb','eb'];
 
      let scaleSequence = [];
      let isFlatScale = flatNotes.includes(this._tonic);

      let tonicIndex = isFlatScale ? this._scaleFlat.findIndex((note) => note === this._tonic) : this._scaleSharp.findIndex((note) => note === this._tonic);

      for (let i = tonicIndex; i < this._scaleFlat.length; i++) {
          scaleSequence.push(isFlatScale ? this._scaleFlat[i] : this._scaleSharp[i]);
      }

      for (let i = 0; i < tonicIndex; i++) {
          scaleSequence.push(isFlatScale ? this._scaleFlat[i] : this._scaleSharp[i]);
      }

      return scaleSequence;
  }

  interval(intervals) {
    throw new Error('Remove this statement and implement this function');
  }
}

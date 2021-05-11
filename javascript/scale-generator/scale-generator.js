export class Scale {
  constructor(tonic) {
      this._tonic = tonic;
      this._scaleSharp = ['A', 'A#', 'B', 'C', 'C#', 'D', 'D#', 'E', 'F', 'F#', 'G', 'G#'];
      this._scaleFlat = ['A', 'Bb', 'B', 'C', 'Db', 'D', 'Eb', 'E', 'F', 'Gb', 'G', 'Ab'];
      this._flatNotes = ['F', 'Bb', 'Eb', 'Ab', 'Db', 'Gb', 'd', 'g', 'c', 'f', 'bb', 'eb'];
      this._isFlatScale = this._flatNotes.includes(this._tonic);
  }

  chromatic() {
      //let flatNotes = ['F', 'Bb', 'Eb', 'Ab', 'Db', 'Gb','d','g','c','f','bb','eb'];
 
      let scaleSequence = [];
      //let isFlatScale = this._flatNotes.includes(this._tonic);

      let tonicIndex = this._isFlatScale ? this._scaleFlat.findIndex((note) => note === this._tonic) : this._scaleSharp.findIndex((note) => note === this._tonic);

      for (let i = tonicIndex; i < this._scaleFlat.length; i++) {
          scaleSequence.push(this._isFlatScale ? this._scaleFlat[i] : this._scaleSharp[i]);
      }

      for (let i = 0; i < tonicIndex; i++) {
          scaleSequence.push(this._isFlatScale ? this._scaleFlat[i] : this._scaleSharp[i]);
      }

      return scaleSequence;
  }

  interval(intervals) {
      let diatonicScales = [];

      let parsedTonic = this._tonic.length == 2 ? `${this._tonic[0].toUpperCase()}${this._tonic[1]}` : this._tonic.toUpperCase();
      let tonicIndex = this._isFlatScale ? this._scaleFlat.findIndex((note) => note === parsedTonic) : this._scaleSharp.findIndex((note) => note === parsedTonic);

      diatonicScales.push(parsedTonic);

      for (let i = 0; i < intervals.length-1; i++) {
          switch (intervals[i]) {
              case 'm':
                  tonicIndex += 1;
                  break;
              case 'M':
                  tonicIndex += 2;
                  break;
              default:
                  tonicIndex += 3;
                  break;
          }

          //console.log(this._scaleSharp[(tonicIndex) % this._scaleSharp.length]);
          diatonicScales.push(this._isFlatScale ? this._scaleFlat[(tonicIndex) % this._scaleFlat.length] : this._scaleSharp[(tonicIndex) % this._scaleSharp.length]);
      }

      return diatonicScales;
  }
}

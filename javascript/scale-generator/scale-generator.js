export class Scale {
  constructor(tonic) {
      this._tonic = tonic;
      this._isFlatScale = ['F', 'Bb', 'Eb', 'Ab', 'Db', 'Gb', 'd', 'g', 'c', 'f', 'bb', 'eb'].includes(this._tonic);

      this._scale = this._isFlatScale ? ['A', 'Bb', 'B', 'C', 'Db', 'D', 'Eb', 'E', 'F', 'Gb', 'G', 'Ab']
                                        : ['A', 'A#', 'B', 'C', 'C#', 'D', 'D#', 'E', 'F', 'F#', 'G', 'G#'];
  }

  chromatic() { 
      let scaleSequence = [];
   
      let tonicIndex = this._scale.findIndex((note) => note === this._tonic);

      for (let i = tonicIndex; i < this._scale.length; i++) {
          scaleSequence.push(this._scale[i]);
      }

      for (let i = 0; i < tonicIndex; i++) {
          scaleSequence.push(this._scale[i]);
      }

      return scaleSequence;
  }

  interval(intervals) {
      let diatonicScales = [];

      let parsedTonic = this._tonic.length == 2 ? `${this._tonic[0].toUpperCase()}${this._tonic[1]}` : this._tonic.toUpperCase();
      let tonicIndex = this._scale.findIndex((note) => note === parsedTonic);

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

          diatonicScales.push(this._scale[(tonicIndex) % this._scale.length]);
      }

      return diatonicScales;
  }
}

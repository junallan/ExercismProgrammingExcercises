export class Series {
  constructor(series) {
      this.series = series;
  }

  slices(sliceLength) {
      let allSlices = [];

      if (this.series.length === 0) { throw Error('series cannot be empty'); }
      if (sliceLength > this.series.length) { throw Error('slice length cannot be greater than series length'); }
      if (sliceLength === 0) { throw Error('slice length cannot be zero'); }
      if (sliceLength < 0) { throw Error('slice length cannot be negative'); }

      for (let i = 0; i + sliceLength <= this.series.length; i++) {
          allSlices.push(this.series.substring(i, i + sliceLength)
                                    .split('')
                                    .map(Number));
      }

      return allSlices;
  }
}

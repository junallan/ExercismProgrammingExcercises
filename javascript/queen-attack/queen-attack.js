const MaxBoardPosition = 7;
const MinBoardPosition = 0;

export class QueenAttack {
  constructor({
      black: [blackRow, blackColumn] = [MaxBoardPosition,3],
      white: [whiteRow, whiteColumn] = [MinBoardPosition,3],
  } = {}) {
      if (blackRow < MinBoardPosition || blackRow > MaxBoardPosition
          || whiteRow < MinBoardPosition || whiteRow > MaxBoardPosition
          || blackColumn < MinBoardPosition || blackColumn > MaxBoardPosition
          || whiteColumn < MinBoardPosition || whiteColumn > MaxBoardPosition) {
          throw new Error('Queen must be placed on the board');
      }

      if (blackRow === whiteRow && blackColumn === whiteColumn) {
          throw new Error('Queens cannot share the same space');
      }
      
      
      this.black = [blackRow, blackColumn];
      this.white = [whiteRow, whiteColumn]; 
  }

  toString() {
    throw new Error('Remove this statement and implement this function');
  }

  get canAttack() {
      return (Math.abs(this.black[0] - this.white[0])) === (Math.abs(this.black[1] - this.white[1]))
                || (this.black[0] === this.white[0])
                || (this.black[1] === this.white[1]);
  }
}

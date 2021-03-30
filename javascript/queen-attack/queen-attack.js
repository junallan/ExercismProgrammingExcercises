const MaxBoardPosition = 7;
const MinBoardPosition = 0;
const BoardLength = 15;

export class QueenAttack {
  constructor({
      black: [blackRow, blackColumn] = [MinBoardPosition,3],
      white: [whiteRow, whiteColumn] = [MaxBoardPosition,3],
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
      let board = '';

      for (let i = 0; i <= MaxBoardPosition; i++) {
          let boardRow = '_ _ _ _ _ _ _ _';

          if (this.white[0] === i) {
              boardRow = boardRow.substr(0, this.white[1] * 2) + 'W'.padEnd(BoardLength - (this.white[1] * 2),' _');
          }

          if (this.black[0] === i) {
              boardRow = boardRow.substr(0, this.black[1] * 2) + 'B'.padEnd(BoardLength - (this.black[1] * 2), ' _');
          }

          board = board.concat(boardRow).concat('\n'); 
      }

      return board.substring(0, board.length - 1);
  }

  get canAttack() {
      return (Math.abs(this.black[0] - this.white[0])) === (Math.abs(this.black[1] - this.white[1]))
                || (this.black[0] === this.white[0])
                || (this.black[1] === this.white[1]);
  }
}

export class BankAccount {
    constructor() {
      this._bankAccountState = { Active: 1, Inactive: 0 };
        this._balance = 0;
        this._state = this._bankAccountState.Inactive;
  }

  open() {
      if (this._state === this._bankAccountState.Active) {
          throw new ValueError();
      }

      this._state = this._bankAccountState.Active;
  }

  close() {
      if (this._state === this._bankAccountState.Inactive) {
          throw new ValueError();
      }

      this._balance = 0;
      this._state = this._bankAccountState.Inactive;
  }

  deposit(money) {
      if (this._state === this._bankAccountState.Inactive ||
          money < 0) {
        throw new ValueError();
      }

      this._balance += money;
  }

  withdraw(money) {
      if (this._state === this._bankAccountState.Inactive ||
          money > this.balance ||
          money < 0) {
          throw new ValueError();
      }

      this._balance -= money;
  }

  get balance() {
       if (this._state === this._bankAccountState.Inactive) {
         throw new ValueError();
       }

       return this._balance;
  }
}

export class ValueError extends Error {
  constructor() {
    super('Bank account error');
  }
}



export class BankAccount {
    constructor() {
        this._balance = 0;
        this._isOpen = false;
  }

  open() {
      if (this._isOpen) { throw new ValueError(); }

      this._isOpen = true;
  }

  close() {
      if (!this._isOpen) { throw new ValueError(); }

      this._balance = 0;
      this._isOpen = false;
  }

  deposit(money) {
      if (!this._isOpen || money < 0) {
        throw new ValueError();
      }

      this._balance += money;
  }

  withdraw(money) {
      if (!this._isOpen || money > this.balance || money < 0) {
          throw new ValueError();
      }

      this._balance -= money;
  }

  get balance() {
       if (!this._isOpen) { throw new ValueError(); }

       return this._balance;
  }
}

export class ValueError extends Error {
  constructor() {
    super('Bank account error');
  }
}



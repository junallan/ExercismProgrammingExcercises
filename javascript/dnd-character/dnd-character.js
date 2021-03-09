export const abilityModifier = (number) => {
    if (number < 3) { throw 'Ability scores must be at least 3'; }
    if (number > 18) { throw 'Ability scores can be at most 18'; }
    return Math.floor((number - 10) / 2);
};

export class Character {
    constructor() {
        this._strength = Character.rollAbility(); 
        this._dexterity = Character.rollAbility();
        this._constitution = Character.rollAbility();
        this._intelligence = Character.rollAbility();
        this._wisdom = Character.rollAbility();
        this._charisma = Character.rollAbility();
    }

    static rollAbility() {
        let diceDotsCount = 6;

        let roles = [Math.floor((Math.random() * diceDotsCount) + 1),
                     Math.floor((Math.random() * diceDotsCount) + 1),
                     Math.floor((Math.random() * diceDotsCount) + 1),
                     Math.floor((Math.random() * diceDotsCount) + 1)]

        roles.sort().shift();

        return roles.reduce((total, roll) => total + roll);
    } 

    get strength() {
        return this._strength;
    };
    get dexterity() {
        return this._dexterity;
    };
    get constitution() {
        return this._constitution;
    };
    get intelligence() {
        return this._intelligence;
    };
    get wisdom() {
        return this._wisdom;
    };   
    get charisma() {
        return this._charisma;
    };
    get hitpoints() { return 10 + abilityModifier(this._constitution) };
}

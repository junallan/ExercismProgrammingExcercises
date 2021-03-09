export const abilityModifier = (number) => {
    if (number < 3) { throw 'Ability scores must be at least 3'; }
    if (number > 18) { throw 'Ability scores can be at most 18'; }
    return Math.floor((number - 10) / 2);
};




export class Character {
    static rollAbility() {
        let diceDotsCount = 6;

        let roles = [Math.floor((Math.random() * diceDotsCount) + 1),
                     Math.floor((Math.random() * diceDotsCount) + 1),
                     Math.floor((Math.random() * diceDotsCount) + 1),
                     Math.floor((Math.random() * diceDotsCount) + 1)]

        roles.sort().shift();

        return roles.reduce((total, roll) => total + roll);
    } 

    static strength = 0;
    static dexterity = 0;
    static constitution = 0;
    static intelligence = 0;
    static wisdom = 0;
    static charisma = 0;

    get strength() {
        if (Character.strength === 0) {
            Character.strength = Character.rollAbility();
        }

        return Character.strength;
    };
    get dexterity() {
        if (Character.dexterity === 0) {
            Character.dexterity = Character.rollAbility();
        }

        return Character.dexterity;
    };
    get constitution() {
        if (Character.constitution === 0) {
            Character.constitution = Character.rollAbility();
        }

        return Character.constitution;
    };
    get intelligence() {
        if (Character.intelligence === 0) {
            Character.intelligence = Character.rollAbility();
        }

        return Character.intelligence;
    };
    get wisdom() {
        if (Character.wisdom === 0) {
            Character.wisdom = Character.rollAbility();
        }

        return Character.wisdom;
    };   
    get charisma() {
        if (Character.charisma === 0) {
            Character.charisma = Character.rollAbility();
        }

        return Character.charisma;
    };
    get hitpoints() { return 10 + abilityModifier(this.constitution) };
}

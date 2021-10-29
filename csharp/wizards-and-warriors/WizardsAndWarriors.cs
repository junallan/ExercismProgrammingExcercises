using System;

abstract class Character
{
    private string _characterType;

    protected Character(string characterType) => _characterType = characterType;

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => false;

    public override string ToString() => $"Character is a {_characterType}";
}

class Warrior : Character
{
    private readonly int DamagePointsWhenVulnurable = 10;
    private readonly int DamagePointsWhenNotVulnurable = 6;

    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target) => target.Vulnerable() ? DamagePointsWhenVulnurable : DamagePointsWhenNotVulnurable;
}

class Wizard : Character
{
    private bool _spellPrepared = false;
    private readonly int DamagePointsWhenSpellPrepared = 12;
    private readonly int DamagePointsWhenSpellNotPrepared = 3;

    public Wizard() : base("Wizard")
    {
    }

    public bool IsSpellPrepared => _spellPrepared;

    public override bool Vulnerable() => !_spellPrepared;

    public override int DamagePoints(Character target) => IsSpellPrepared ? DamagePointsWhenSpellPrepared : DamagePointsWhenSpellNotPrepared;

    public void PrepareSpell() => _spellPrepared = true;
}

using System;

abstract class Character
{
    private string _characterType;

    protected bool _isVulnerable = false;

    protected Character(string characterType)
    {
        _characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return _isVulnerable;
    }

    public override string ToString()
    {
        return $"Character is a {_characterType}";
    }
}

class Warrior : Character
{
    private readonly int DamagePointsWhenVulnurable = 10;
    private readonly int DamagePointsWhenNotVulnurable = 6;

    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
       return target.Vulnerable() ? DamagePointsWhenVulnurable : DamagePointsWhenNotVulnurable;
    }
}

class Wizard : Character
{
    private bool _spellPrepared = false;

    private readonly int DamagePointsWhenSpellPrepared = 12;
    private readonly int DamagePointsWhenSpellNotPrepared = 3;

    public Wizard() : base("Wizard")
    {
        _isVulnerable = true;
    }

    public bool IsSpellPrepared => _spellPrepared;

    public override int DamagePoints(Character target)
    {
       return IsSpellPrepared ? DamagePointsWhenSpellPrepared : DamagePointsWhenSpellNotPrepared;
    }

    public void PrepareSpell()
    {
        _spellPrepared = true;
        _isVulnerable = false;
    }
}

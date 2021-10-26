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
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        throw new NotImplementedException("Please implement the Warrior.DamagePoints() method");
    }
}

class Wizard : Character
{
    private bool _spellPrepared = false;

    public Wizard() : base("Wizard")
    {
        _isVulnerable = true;
    }

    public override int DamagePoints(Character target)
    {
        throw new NotImplementedException("Please implement the Wizard.DamagePoints() method");
    }

    public void PrepareSpell()
    {
        _spellPrepared = true;
        _isVulnerable = false;
    }
}

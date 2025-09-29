abstract class Character
{
    string characterType;
    protected Character(string characterType)
    {
        this.characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public abstract bool Vulnerable();

    public override string ToString()
    {
        return $"Character is a {characterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override bool Vulnerable()
    {
        return false;
    }
    public override int DamagePoints(Character target)
    {
        return target.Vulnerable() ? 10 : 6;
    }
}

class Wizard : Character
{
    bool IsPreparing = false;
    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target)
    {
        return IsPreparing ? 12 : 3;
    }

    public override bool Vulnerable()
    {
        if (IsPreparing)
        {
            return false;
        }
        return true;
    }
    public void PrepareSpell()
    {
        IsPreparing = true;
    }
}

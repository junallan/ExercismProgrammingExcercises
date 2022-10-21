using System;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency; 
    }

    public static CurrencyAmount operator + (CurrencyAmount a, CurrencyAmount b)
    {
        if(a.currency != b.currency) throw new ArgumentException();

        return new CurrencyAmount(a.amount + b.amount, a.currency);
    } 

    public static bool operator == (CurrencyAmount a, CurrencyAmount b) => a.Equals(b);
    public static bool operator != (CurrencyAmount a, CurrencyAmount b) => !a.Equals(b);

    public override int GetHashCode() => HashCode.Combine(this.amount, this.currency);

    public override bool Equals(object obj) => Equals((CurrencyAmount)obj);

    public bool Equals(CurrencyAmount other) 
    {
        if(this.currency != other.currency) throw new ArgumentException();

        return this.amount == other.amount && this.currency == other.currency;
    }

    
    // TODO: implement comparison operators

    // TODO: implement arithmetic operators

    // TODO: implement type conversion operators
}

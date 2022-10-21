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

    public static CurrencyAmount operator - (CurrencyAmount a, CurrencyAmount b)
    {
        if(a.currency != b.currency) throw new ArgumentException();

        return new CurrencyAmount(a.amount - b.amount, a.currency);
    }

    public static CurrencyAmount operator *(CurrencyAmount a, decimal factor) => new CurrencyAmount(a.amount * factor, a.currency);

    public static CurrencyAmount operator * (decimal factor, CurrencyAmount a) => new CurrencyAmount(a.amount * factor, a.currency);
    
    public static CurrencyAmount operator / (CurrencyAmount a, decimal divisor) => new CurrencyAmount(a.amount / divisor, a.currency);

    public static explicit operator double(CurrencyAmount a) => Convert.ToDouble(a.amount);

    public static implicit operator decimal(CurrencyAmount a) => a.amount;

    public static bool operator > (CurrencyAmount a, CurrencyAmount b)
    {
        if(a.currency != b.currency) throw new ArgumentException();

        return a.amount > b.amount;
    }
    public static bool operator < (CurrencyAmount a, CurrencyAmount b)
    {
        if(a.currency != b.currency) throw new ArgumentException();

        return a.amount < b.amount;
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
}

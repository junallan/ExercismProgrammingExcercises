using System;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            return checked(@base * multiplier).ToString();
        }
        catch (System.OverflowException)
        {
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        var gdp = (@base * multiplier).ToString();
        
        return gdp == "Infinity" ? "*** Too Big ***" : gdp;
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        throw new NotImplementedException($"Please implement the (static) CentralBank.DisplayChiefEconomistSalary() method");
    }
}

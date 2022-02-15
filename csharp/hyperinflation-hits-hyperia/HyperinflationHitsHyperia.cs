using System;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
       // string denomination = string.Empty;
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
        throw new NotImplementedException($"Please implement the (static) CentralBank.DisplayGDP() method");
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        throw new NotImplementedException($"Please implement the (static) CentralBank.DisplayChiefEconomistSalary() method");
    }
}

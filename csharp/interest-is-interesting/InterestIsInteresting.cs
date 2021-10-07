using System;

static class SavingsAccount
{
    public static float InterestRate(decimal balance) => balance switch { < 0 => -3.213f, < 1000 => 0.5f, < 5000 => 1.621f, _ => 2.475f };

    public static decimal Interest(decimal balance)
    {
        decimal interestRatePercentage = (decimal)(InterestRate(balance) / 100);
        
        return interestRatePercentage * Math.Abs(balance);
    }

    public static decimal AnnualBalanceUpdate(decimal balance) => balance + Interest(balance);

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int yearsOfInterest = 0;

        do
        {
            balance = AnnualBalanceUpdate(balance);
            yearsOfInterest++;
        } while (balance < targetBalance);

        return yearsOfInterest;
    }
}

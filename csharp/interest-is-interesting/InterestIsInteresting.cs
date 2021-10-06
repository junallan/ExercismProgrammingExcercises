using System;

static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        if (balance < 0) return -3.213f;
        else if (balance < 1000) return 0.5f;
        else if (balance < 5000) return 1.621f;
        else return 2.475f;
    }

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

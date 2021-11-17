using System;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation)
    {
        return operation switch
        {
            "+" => $"{operand1} {operation} {operand2} = {operand1 + operand2}",
        };
    }
}

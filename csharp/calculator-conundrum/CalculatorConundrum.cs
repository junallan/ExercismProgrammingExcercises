using System;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation)
    {
        var expression = $"{operand1} {operation} {operand2}";

        return operation switch
        {
            "+" => $"{expression} = {operand1 + operand2}",
            "*" => $"{expression} = {operand1 * operand2}",
            "/" => operand2 != 0 ? $"{expression} = {operand1 / operand2}" : "Division by zero is not allowed.",          
            "" => throw new ArgumentException(),
            null => throw new ArgumentNullException(),
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
}

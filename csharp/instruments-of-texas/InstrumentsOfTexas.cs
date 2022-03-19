using System;

public class CalculationException : Exception
{
    public CalculationException(int operand1, int operand2, string message, Exception inner)
    {
        Operand1 = operand1;
        Operand2 = operand2;
    }

    public int Operand1 { get; }
    public int Operand2 { get; }
}

public class CalculatorTestHarness
{
    private Calculator calculator;

    public CalculatorTestHarness(Calculator calculator)
    {
        this.calculator = calculator;
    }

    public string TestMultiplication(int x, int y)
    {
        try
        {
            this.calculator.Multiply(x, y);

            return "Multiply succeeded";
        }
        catch(Exception ex)
        {
            throw new CalculationException(x,y,string.Empty, ex);
        }
       
    }

    public void Multiply(int x, int y)
    {
        TestMultiplication(x,y);
         //throw new CalculationException(x,y,string.Empty,new Exception());
    }
}


// Please do not modify the code below.
// If there is an overflow in the multiplication operation
// then a System.OverflowException is thrown.
public class Calculator
{
    public int Multiply(int x, int y)
    {
        checked
        {
            return x * y;
        }
    }
}

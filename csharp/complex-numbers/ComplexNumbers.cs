using System;

public struct ComplexNumber
{
    private readonly double _real;
    private readonly double _imaginary;

    public ComplexNumber(double real, double imaginary)
    {
        _real = real;
        _imaginary = imaginary;
    }

    public double Real()
    {
        return _real;
    }

    public double Imaginary()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public ComplexNumber Mul(ComplexNumber other)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public ComplexNumber Add(ComplexNumber other)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public ComplexNumber Sub(ComplexNumber other)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public ComplexNumber Div(ComplexNumber other)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public double Abs()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public ComplexNumber Conjugate()
    {
        throw new NotImplementedException("You need to implement this function.");
    }
    
    public ComplexNumber Exp()
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
using System;

public struct ComplexNumber
{
    private readonly double _a;
    private readonly double _b;

    public ComplexNumber(double real, double imaginary)
    {
        _a= real;
        _b = imaginary;
    }

    public double Real()
    {
        return _a;
    }

    public double Imaginary()
    {
        return _b;
    }

    public ComplexNumber Mul(ComplexNumber other)
    {
        var c = other.Real();
        var d = other.Imaginary();
        
        var real = _a * c - _b * d;
        var imaginary = _b * c + _a * d;

        return new ComplexNumber(real, imaginary);
    }

    public ComplexNumber Add(ComplexNumber other)
    {
        var c = other.Real();
        var d = other.Imaginary();

        var real = _a + c;
        var imaginary = _b + d;

        return new ComplexNumber(real, imaginary);
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
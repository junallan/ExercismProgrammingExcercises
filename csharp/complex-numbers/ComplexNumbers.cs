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
        var c = other.Real();
        var d = other.Imaginary();

        var real = _a - c;
        var imaginary = _b - d;

        return new ComplexNumber(real, imaginary);
    }

    public ComplexNumber Div(ComplexNumber other)
    {
        var c = other.Real();
        var d = other.Imaginary();

        var divisor = (Math.Pow(c,2) + Math.Pow(d,2));
        var real = (_a * c + _b * d) / divisor;
        var imaginary = (_b * c - _a * d) / divisor;

        return new ComplexNumber(real, imaginary);
    }

    public double Abs() => Math.Sqrt(Math.Pow(_a,2) + Math.Pow(_b,2));
    

    public ComplexNumber Conjugate()
    {
        throw new NotImplementedException("You need to implement this function.");
    }
    
    public ComplexNumber Exp()
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
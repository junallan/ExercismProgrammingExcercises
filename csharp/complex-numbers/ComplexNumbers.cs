using System;

public struct ComplexNumber
{
    private readonly double _real;
    private readonly double _imaginary;

    public ComplexNumber(double real, double imaginary)
    {
        _real= real;
        _imaginary = imaginary;
    }

    public double Real()
    {
        return _real;
    }

    public double Imaginary()
    {
        return _imaginary;
    }

    public ComplexNumber Mul(ComplexNumber other)
    {
        var otherReal = other.Real();
        var otherImaginary = other.Imaginary();
        
        var real = _real * otherReal - _imaginary * otherImaginary;
        var imaginary = _imaginary * otherReal + _real * otherImaginary;

        return new ComplexNumber(real, imaginary);
    }

    public ComplexNumber Mul(int factor)
    {
        var otherReal = factor;
        var otherImaginary = 0;
        
        var real = _real * otherReal - _imaginary * otherImaginary;
        var imaginary = _imaginary * otherReal + _real * otherImaginary;

        return new ComplexNumber(real, imaginary);
    }

    public ComplexNumber Add(int factor)
    {
        var otherReal = factor;
        var otherImaginary = 0;

        var real = _real + otherReal;
        var imaginary = _imaginary + otherImaginary;

        return new ComplexNumber(real, imaginary);
    }

    public ComplexNumber Add(ComplexNumber other)
    {
        var otherReal = other.Real();
        var otherImaginary = other.Imaginary();

        var real = _real + otherReal;
        var imaginary = _imaginary + otherImaginary;

        return new ComplexNumber(real, imaginary);
    }

    public ComplexNumber Sub(ComplexNumber other)
    {
        var otherReal = other.Real();
        var otherImaginary = other.Imaginary();

        var real = _real - otherReal;
        var imaginary = _imaginary - otherImaginary;

        return new ComplexNumber(real, imaginary);
    }

    public ComplexNumber Div(ComplexNumber other)
    {
        var otherReal = other.Real();
        var otherImaginary = other.Imaginary();

        var divisor = (Math.Pow(otherReal,2) + Math.Pow(otherImaginary,2));
        var real = (_real * otherReal + _imaginary * otherImaginary) / divisor;
        var imaginary = (_imaginary * otherReal - _real * otherImaginary) / divisor;

        return new ComplexNumber(real, imaginary);
    }

    public ComplexNumber Div(int factor)
    {
        var otherReal = factor;
        var otherImaginary = 0;

        var divisor = (Math.Pow(otherReal,2) + Math.Pow(otherImaginary,2));
        var real = (_real * otherReal + _imaginary * otherImaginary) / divisor;
        var imaginary = (_imaginary * otherReal - _real * otherImaginary) / divisor;

        return new ComplexNumber(real, imaginary);
    }

    public double Abs() => Math.Sqrt(Math.Pow(_real,2) + Math.Pow(_imaginary,2));
    
    public ComplexNumber Conjugate() => new ComplexNumber(_real, -_imaginary);
    
    public ComplexNumber Exp() => new ComplexNumber(Math.Exp(_real) * Math.Cos(_imaginary), Math.Exp(_real) * Math.Sin(_imaginary));
}
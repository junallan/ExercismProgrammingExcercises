using System;

class WeighingMachine
{
    private double weight;
    private string displayWeight;

    public int Precision { get; }
    public double Weight {
        get => weight; 
        set { 
            if(value < 0) throw new ArgumentOutOfRangeException(); 
            weight = value; 
        }
    }

    public double TareAdjustment { get;set; } = 5;
    public string DisplayWeight => $"{(Weight - TareAdjustment).ToString($"F{Precision}")} kg";  
    

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }
}

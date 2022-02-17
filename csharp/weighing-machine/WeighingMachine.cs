using System;

class WeighingMachine
{
    private double weight;
    private string displayWeight;

    public int Precision { get;set; }
    public double Weight {
        get { return weight; }
        set { 
            if(value < 0) throw new ArgumentOutOfRangeException(); 
            else weight = value; }
        }
    public double TareAdjustment { get;set; } = 5;
    public string DisplayWeight { 
        get { return $"{(Weight - TareAdjustment).ToString($"F{Precision}")} kg"; } 
    }

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }
}

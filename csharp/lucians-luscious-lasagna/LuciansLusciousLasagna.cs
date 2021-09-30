public class Lasagna
{
    public readonly int OvenTime = 40;
    public readonly int LayerPrepTime = 2;

    public int ExpectedMinutesInOven() => OvenTime;
    public int RemainingMinutesInOven(int cookTime) => OvenTime - cookTime;
    public int PreparationTimeInMinutes(int layers) => LayerPrepTime * layers;
    public int ElapsedTimeInMinutes(int layers, int cookTime) => PreparationTimeInMinutes(layers) + cookTime;
}

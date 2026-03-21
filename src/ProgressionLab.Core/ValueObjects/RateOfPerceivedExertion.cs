namespace ProgressionLab.Core.ValueObjects;

public readonly record struct RateOfPerceivedExertion 
{
  public RateOfPerceivedExertion(decimal value)
  {
    if (value < 1m)
      throw new ArgumentOutOfRangeException(nameof(value), "RPE must be greater than or equal to 1.");
    if (value > 10m)
      throw new ArgumentOutOfRangeException(nameof(value), "RPE must be less than or equal to 10.");
    if (value % 0.5m != 0m)
      throw new ArgumentOutOfRangeException(nameof(value), "RPE must be divisible by 0.5.");
    Value = value;
  }

  public decimal Value { get; }
}

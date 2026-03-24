using Vogen;

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
  
  public static RateOfPerceivedExertion Of(decimal rpe) => new(rpe);

  public decimal Value { get; }
}

[ValueObject<decimal>]                                                                                                                                                                                          
public readonly partial struct RPE                                                                                                                                                                              
{                                                                                                                                                                                                               
  private static Validation Validate(decimal value)
  {                                                                                                                                                                                                           
    if (value < 1m)
      return Validation.Invalid("RPE must be >= 1.");
    if (value > 10m)                                                                                                                                                                                        
      return Validation.Invalid("RPE must be <= 10.");
    if (value % 0.5m != 0m)                                                                                                                                                                                 
      return Validation.Invalid("RPE must be divisible by 0.5.");
    return Validation.Ok;                                                                                                                                                                                   
  }
}  

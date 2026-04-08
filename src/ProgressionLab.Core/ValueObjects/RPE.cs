using Vogen;

namespace ProgressionLab.Core.ValueObjects;

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

using Vogen;

namespace ProgressionLab.Core.ProgramAggregate;

[ValueObject<int>]
public readonly partial struct WeekNumber
{
  private static Validation Validate(in int number)
  {
    if (number < 1)
      return Validation.Invalid("Week number must be greater than or equal to one");
    
    return Validation.Ok;
  }
}

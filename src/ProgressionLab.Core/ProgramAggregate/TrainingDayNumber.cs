using Vogen;

namespace ProgressionLab.Core.ProgramAggregate;

[ValueObject<int>]
public readonly partial struct TrainingDayNumber
{
  private static Validation Validate(in int number)
  {
    if (number < 1)
      return Validation.Invalid("Training day number must be greater than or equal to one");

    if (number > 7)
      return Validation.Invalid("Cannot exceed seven training days in a week");      

    return Validation.Ok;
  }
}

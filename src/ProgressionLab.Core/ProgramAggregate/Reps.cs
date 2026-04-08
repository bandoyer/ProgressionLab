using Vogen;

namespace ProgressionLab.Core.ProgramAggregate;

[ValueObject<int>]
public readonly partial struct Reps
{
  private static Validation Validate(int reps)
  {
    if (reps < 1)
      return Validation.Invalid("Reps must be greater than or equal to one");

    return Validation.Ok;
  }
}

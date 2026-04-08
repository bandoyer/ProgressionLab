using Vogen;

namespace ProgressionLab.Core.ProgramAggregate;

[ValueObject<decimal>]
public readonly partial struct Weight
{
  private static Validation Validate(decimal weight)
  {
    if (weight < 1)
      return Validation.Invalid("Weight must be greater than or equal to one");

    return Validation.Ok;
  }
}

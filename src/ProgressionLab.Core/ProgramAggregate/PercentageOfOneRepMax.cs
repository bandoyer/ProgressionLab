using Vogen;

namespace ProgressionLab.Core.ProgramAggregate;

[ValueObject<decimal>]
public readonly partial struct PercentageOfOneRepMax
{
  private static Validation Validate(decimal percentage)
  {
    if (percentage is <= 0 or > 100)
      return Validation.Invalid("Percentage of e1RM must be between 1 and 100");

    return Validation.Ok;
  }
}

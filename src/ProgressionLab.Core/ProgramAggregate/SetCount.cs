using Vogen;

namespace ProgressionLab.Core.ProgramAggregate;

[ValueObject<int>]
public readonly partial struct SetCount
{
  private static Validation Validate(int setCount)
  {
    if (setCount < 1)
      return Validation.Invalid("Set count must be greater than or equal to one");

    return Validation.Ok;
  }
}

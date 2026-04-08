using ProgressionLab.Core.ProgramAggregate;

namespace ProgressionLab.UnitTests.Core.ProgramAggregate;

public class WeightTests
{
  [Theory]
  [InlineData(0)]
  [InlineData(-1)]
  public void WeightCannotBeBelowOne(decimal weight)
  {
    Should.Throw<Vogen.ValueObjectValidationException>(() => Weight.From(weight));
  }
}

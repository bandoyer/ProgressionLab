using ProgressionLab.Core.ValueObjects;

namespace ProgressionLab.UnitTests.Core.ValueObjects;

public class RpeTests
{
  [Fact]
  public void CanCreateRpeOfTen()
  {
    var rpe10 = RPE.From(10);
    rpe10.Value.ShouldBe(10);
  }

  [Fact]
  public void CanCreateRpeOfNinePointFive()
  {
    var rpe95 = RPE.From(9.5m);
    rpe95.Value.ShouldBe(9.5m);
  }

  [Fact]
  public void CannotCreateRpeGreaterThanTen()
  {
    Should.Throw<Vogen.ValueObjectValidationException>(() => RPE.From(11));
  }
  
  [Fact]
  public void CannotCreateRpeLessThanOne()
  {
    Should.Throw<Vogen.ValueObjectValidationException>(() => RPE.From(0));
  }

  [Fact]
  public void CannotCreateRpeThatIsNotDivisibleByHalf()
  {
    Should.Throw<Vogen.ValueObjectValidationException>(() => RPE.From(9.7m));
  }
  
  [Fact]
  public void TwoRpesAreEqual()
  {
    var rpe10 = RPE.From(10);
    var rpe10Again = RPE.From(10);
    rpe10.ShouldBe(rpe10Again);
  }
}

using ProgressionLab.Core.ValueObjects;

namespace ProgressionLab.UnitTests.Core.ValueObjects;

public class RpeTests
{
  [Fact]
  public void CanCreateRpeOfTen()
  {
    var rpe10 = new RateOfPerceivedExertion(10);
    rpe10.Value.ShouldBe(10);
  }

  [Fact]
  public void CanCreateRpeOfNinePointFive()
  {
    var rpe95 = new RateOfPerceivedExertion(9.5m);
    rpe95.Value.ShouldBe(9.5m);
  }

  [Fact]
  public void CannotCreateRpeGreaterThanTen()
  {
    Should.Throw<ArgumentOutOfRangeException>(() => new RateOfPerceivedExertion(11));
  }
  
  [Fact]
  public void CannotCreateRpeLessThanOne()
  {
    Should.Throw<ArgumentOutOfRangeException>(() => new RateOfPerceivedExertion(0));
  }

  [Fact]
  public void CannotCreateRpeThatIsNotDivisibleByHalf()
  {
    Should.Throw<ArgumentOutOfRangeException>(() => new RateOfPerceivedExertion(9.7m));
  }
  
  [Fact]
  public void TwoRpesAreEqual()
  {
    var rpe10 = new RateOfPerceivedExertion(10);
    var rpe10Again = new RateOfPerceivedExertion(10);
    rpe10.ShouldBe(rpe10Again);
  }
}

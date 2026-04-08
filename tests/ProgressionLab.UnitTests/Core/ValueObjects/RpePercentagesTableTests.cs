using ProgressionLab.Core;
using ProgressionLab.Core.ValueObjects;

namespace ProgressionLab.UnitTests.Core.ValueObjects;

public class RpePercentagesTableTests
{
  [Fact]
  public void GivenOneRepAtRpeTenReturnCorrespondingPercentage()
  {
    var reps = 1;
    var rpe = RPE.From(10);
    var rpePercentage = RpePercentages.Get(reps, rpe);
    rpePercentage.ShouldBe(1);
  }
  
  [Theory]
  [InlineData(1)]
  [InlineData(2)]
  [InlineData(3)]
  [InlineData(4)]
  [InlineData(5)]
  public void PercentageTableCannotCalculateRpeBelowSix(decimal rpe)
  {
    Should.Throw<DomainException>(() => RpePercentages.Get(1, RPE.From(rpe)));
  }
}

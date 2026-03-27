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
}

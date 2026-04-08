using ProgressionLab.Core;
using ProgressionLab.Core.RPE;
using Reps = ProgressionLab.Core.ProgramAggregate.Reps;

namespace ProgressionLab.UnitTests.Core.RPETests;

public class RpePercentagesTableTests
{
  [Fact]
  public void GivenOneRepAtRpeTenReturnCorrespondingPercentage()
  {
    var reps = Reps.From(1);
    var rpe = ProgressionLab.Core.RPE.RPE.From(10);
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
    Should.Throw<DomainException>(() => RpePercentages.Get(Reps.From(1), ProgressionLab.Core.RPE.RPE.From(rpe)));
  }
}

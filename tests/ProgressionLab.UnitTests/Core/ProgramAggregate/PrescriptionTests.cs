using ProgressionLab.Core.ProgramAggregate;
using ProgressionLab.Core.RPE;

namespace ProgressionLab.UnitTests.Core.ProgramAggregate;

public class PrescriptionTests
{
  [Fact]
  public void PrescriptionCanIncludePercentageOfEstimatedOneRepMax()
  {
    var prescription = new Prescription(Reps.From(1), RPE.From(10), SetCount.From(1), PercentageOfOneRepMax.From(88));
    prescription.PercentageOfOneRepMax.ShouldBe(PercentageOfOneRepMax.From(88));
  }

  [Theory]
  [InlineData(0)]
  [InlineData(-1)]
  [InlineData(101)]
  public void PercentageOfEstimatedOneRepMaxMustBeBetweenOneAndOneHundred(decimal percentage)
  {
    Should.Throw<Vogen.ValueObjectValidationException>(() => PercentageOfOneRepMax.From(percentage));
  }
}

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

  [Fact]
  public void SlotCanHaveMultiplePrescriptions()
  {
    var slot = new Program(ProgramName.From("prog name"))
      .CreateBlock(BlockName.From("block one"))
      .CreateWeek()
      .CreateTrainingDay()
      .CreateSlot();
    
    slot.SetPrescription(new Prescription(Reps.From(1), RPE.From(9), SetCount.From(4)));
    slot.SetPrescription(new Prescription(Reps.From(4), RPE.From(8), SetCount.From(6)));

    slot.GetPrescriptions().Count.ShouldBe(2);
  }
}

using ProgressionLab.Core.ProgramAggregate;
using ProgressionLab.Core.RPE;
using Reps = ProgressionLab.Core.ProgramAggregate.Reps;
using SetCount = ProgressionLab.Core.ProgramAggregate.SetCount;

namespace ProgressionLab.UnitTests.Core.ProgramAggregate;

// slot has an ExerciseCategory AND Prescription
public class TrainingDaySlotTests
{
  [Fact]
  public void TrainingDayCanAddSingleSlot()
  {
    var program = new Program(ProgramName.From("test prog"));
    var block = program.CreateBlock(BlockName.From("test block"));
    var week = block.CreateWeek();
    var trainingDay = week.CreateTrainingDay();
    var slot = trainingDay.CreateSlot();
    slot.ShouldNotBeNull();
  }

  [Fact]
  public void TrainingDayCanHaveMultipleSlots()
  {
    var program = new Program(ProgramName.From("test prog"));
    var block = program.CreateBlock(BlockName.From("test block"));
    var week = block.CreateWeek();
    var trainingDay = week.CreateTrainingDay();
    trainingDay.CreateSlot();
    trainingDay.CreateSlot();

    var slots = trainingDay.GetSlots();
    slots.Count.ShouldBe(2);
  }
  
  [Fact]
  public void SlotCanHaveAPrescription()
  {
    var slot = new Slot();

    slot.SetPrescription(new Prescription(
      Reps.From(4),
      RPE.From(8),
      SetCount.From(1)));

    slot.GetPrescriptions().Count.ShouldBe(1);
  }

  [Theory]
  [InlineData(0)]
  [InlineData(-1)]
  public void RepsMustBePositive(int reps)
  {
    var slot = new Slot();

    var action = () => slot.SetPrescription(new Prescription(
      Reps.From(reps),
      RPE.From(8),
      SetCount.From(1)));

    action.ShouldThrow<Vogen.ValueObjectValidationException>();
  }

  [Theory]
  [InlineData(0)]
  [InlineData(10.5)]
  public void RpeMustBeBetweenOneAndTen(decimal rpe)
  {
    var slot = new Slot();

    var action = () => slot.SetPrescription(new Prescription(
      Reps.From(4),
      RPE.From(rpe),
      SetCount.From(1)));

    action.ShouldThrow<Vogen.ValueObjectValidationException>();
  }
  
  [Theory]
  [InlineData(0)]
  [InlineData(-1)]
  public void SetCountMustBePositive(int setCount)
  {
    var slot = new Slot();

    var action = () => slot.SetPrescription(new Prescription(
      Reps.From(4),
      RPE.From(8),
      SetCount.From(setCount)));

    action.ShouldThrow<Vogen.ValueObjectValidationException>();
  }
}

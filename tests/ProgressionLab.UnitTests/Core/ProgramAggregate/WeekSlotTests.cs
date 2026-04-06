using ProgressionLab.Core.ProgramAggregate;

namespace ProgressionLab.UnitTests.Core.ProgramAggregate;

// a week contains slots
  
// slot has an ExerciseCategory AND Prescription
public class WeekSlotTests
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
}

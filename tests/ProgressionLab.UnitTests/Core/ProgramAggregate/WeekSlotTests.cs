using ProgressionLab.Core.ProgramAggregate;

namespace ProgressionLab.UnitTests.Core.ProgramAggregate;

// a week contains slots
  
// slot has an ExerciseCategory AND Prescription
public class WeekSlotTests
{
  [Fact]
  public void WeekCanAddSingleSlot()
  {
    var program = new Program(ProgramName.From("test prog"));
    var block = program.CreateBlock(BlockName.From("test block"));
    var week = block.CreateWeek();
    var slot = week.CreateSlot();
    slot.ShouldNotBeNull();
  }

  [Fact]
  public void WeekCanHaveMultipleSlots()
  {
    var program = new Program(ProgramName.From("test prog"));
    var block = program.CreateBlock(BlockName.From("test block"));
    var week = block.CreateWeek();
    week.CreateSlot();
    week.CreateSlot();

    var slots = week.GetSlots();
    slots.Count.ShouldBe(2);
  }
}

using ProgressionLab.Core.ProgramAggregate;

namespace ProgressionLab.UnitTests.Core.ProgramAggregate;

public class WeekRemovalTests
{
  [Fact]
  public void BlockCanRemoveWeek()
  {
    var program = new Program(ProgramName.From("test prog"));
    var block = program.CreateBlock(BlockName.From("block 1"));
    var week = block.CreateWeek();

    block.RemoveWeek(week);
    block.GetWeeks().ShouldBeEmpty();
  }

  [Fact]
  public void BlockCanRemoveWeekByNumber()
  {
    var program = new Program(ProgramName.From("test prog"));
    var block = program.CreateBlock(BlockName.From("block 1"));
    var week = block.CreateWeek();
    
    block.RemoveWeek(WeekNumber.From(week.Number.Value));
    block.GetWeeks().ShouldBeEmpty();
  }
}

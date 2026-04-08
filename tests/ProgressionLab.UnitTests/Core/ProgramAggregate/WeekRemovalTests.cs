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
  
  [Fact]
  public void RemovingWeekThatDoesNotExistWillSkipAndContinue()
  {
    var program = new Program(ProgramName.From("test prog"));
    var block = program.CreateBlock(BlockName.From("block 1"));
    var week = block.CreateWeek();
    block.RemoveWeek(WeekNumber.From(week.Number.Value + 1)); // invalid week number
    
    block.GetWeeks().Count.ShouldBe(1);
  }

  [Fact]
  public void RemovingFinalWeekAllowsNextWeekToReuseFinalWeekNumber()
  {
    var program = new Program(ProgramName.From("test prog"));
    var block = program.CreateBlock(BlockName.From("block 1"));
    block.CreateWeek();
    var finalWeek = block.CreateWeek();
    block.RemoveWeek(finalWeek);

    block.CreateWeek();
    block.GetWeeks().Count.ShouldBe(2);
    block.GetWeeks().Single(w => w.Number == WeekNumber.From(2)).Number.Value.ShouldBe(2);
  }
}

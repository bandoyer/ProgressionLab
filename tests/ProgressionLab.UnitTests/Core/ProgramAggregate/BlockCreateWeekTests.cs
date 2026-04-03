using ProgressionLab.Core.ProgramAggregate;

namespace ProgressionLab.UnitTests.Core.ProgramAggregate;

public class BlockCreateWeekTests
{
  [Fact]
  public void ProgramBlockCanHaveZeroWeeksWhileSettingUp()
  {
    var program = new Program(ProgramName.From("test program"));
    program.AddBlock(BlockName.From("block 1"));

    var block = program.GetBlocks().Single();

    block.GetWeeks().Count.ShouldBe(0);
  }

  [Fact]
  public void ProgramBlocksCanHaveOneWeek()
  {
    var program = new Program(ProgramName.From("test program"));
    program.AddBlock(BlockName.From("block 1"));

    var block = program.GetBlocks().Single();
    block.CreateWeek();

    block.GetWeeks().Count.ShouldBe(1);
  }

  [Fact]
  public void ProgramBlocksCanHaveMultipleWeeks()
  {
    var program = new Program(ProgramName.From("test program"));
    program.AddBlock(BlockName.From("block 1"));

    var block = program.GetBlocks().Single();
    block.CreateWeek();
    block.CreateWeek();

    block.GetWeeks().Count.ShouldBe(2);
  }

  [Fact]
  public void BlockWeekWillAlwaysStartWithOne()
  {
    var program = new Program(ProgramName.From("test program"));
    program.AddBlock(BlockName.From("block 1"));

    var block = program.GetBlocks().Single();
    block.CreateWeek();
    
    var week = program.GetBlocks().Single().GetWeeks().Single();
    week.Number.Value.ShouldBe(1);
  }

  [Fact]
  public void AddingSecondWeekWillWillAutoAssignNumberOfTwo()
  {
    var program = new Program(ProgramName.From("test program"));
    program.AddBlock(BlockName.From("block 1"));

    var block = program.GetBlocks().Single();
    block.CreateWeek();
    block.CreateWeek();

    var weeks = block.GetWeeks();
    weeks.Count.ShouldBe(2);
    weeks.Single(w => w.Number == WeekNumber.From(2))
      .ShouldNotBeNull();
  }
}

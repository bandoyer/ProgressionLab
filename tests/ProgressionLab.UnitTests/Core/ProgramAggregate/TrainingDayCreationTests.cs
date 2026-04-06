using ProgressionLab.Core.ProgramAggregate;
using ProgressionLab.Core.ProgramAggregate.Exceptions;

namespace ProgressionLab.UnitTests.Core.ProgramAggregate;

public class TrainingDayCreationTests
{
  [Fact]
  public void WeekCanCreateTrainingDay()
  {
    var program = new Program(ProgramName.From("test prog"));
    var trainingDay = 
      program
        .CreateBlock(BlockName.From("block 1"))
        .CreateWeek()
        .CreateTrainingDay();

    trainingDay.ShouldNotBeNull();
  }

  [Fact]
  public void WeekCanHaveMultipleTrainingDays()
  {
    var program = new Program(ProgramName.From("test prog"));
    var block = program.CreateBlock(BlockName.From("block 1"));
    var week = block.CreateWeek();
    week.CreateTrainingDay();
    week.CreateTrainingDay();

    var trainingDays = week.GetTrainingDays();
    trainingDays.Count.ShouldBe(2);
  }

  [Fact]
  public void FirstTrainingDayWillAlwaysBeValueOfOne()
  {
    var program = new Program(ProgramName.From("test prog"));
    var block = program.CreateBlock(BlockName.From("block 1"));
    var week = block.CreateWeek();
    var trainingDay = week.CreateTrainingDay();
    trainingDay.Number.Value.ShouldBe(1);
  }
  
  [Fact]
  public void SecondTrainingDayWillAlwaysBeValueOfTwo()
  {
    var program = new Program(ProgramName.From("test prog"));
    var block = program.CreateBlock(BlockName.From("block 1"));
    var week = block.CreateWeek();
    week.CreateTrainingDay();
    var trainingDay = week.CreateTrainingDay();
    trainingDay.Number.Value.ShouldBe(2);
  }

  [Fact]
  public void WeekCannotHaveMoreThanSevenTrainingDays()
  {
    var program = new Program(ProgramName.From("test prog"));
    var week = program
      .CreateBlock(BlockName.From("block 1"))
      .CreateWeek();

    week.CreateTrainingDay();
    week.CreateTrainingDay();
    week.CreateTrainingDay();
    week.CreateTrainingDay();
    week.CreateTrainingDay();
    week.CreateTrainingDay();
    week.CreateTrainingDay();
    var action = () => week.CreateTrainingDay();

    action.ShouldThrow<Vogen.ValueObjectValidationException>();
  }
}

using ProgressionLab.Core.ProgramAggregate;

namespace ProgressionLab.UnitTests.Core.ProgramAggregate;

public class ProgramAddBlockTests
{
  [Fact]
  public void ProgramsCanAddBlocks()
  {
    var program = new Program(ProgramName.From("Test program"));
    program.AddBlock(BlockName.From("test"));
    program.GetBlocks().Count.ShouldBe(1);
  }

  [Fact]
  public void ProgramBlockCanBeNamed()
  {
    var program = new Program(ProgramName.From("Test program"));
    program.AddBlock(BlockName.From("Block I"));
    program.GetBlocks().Single().Name.Value.ShouldBe("Block I");
  }

  [Fact]
  public void ProgramBlockNameWillBeTrimmedWhenCreated()
  {
    var block = new Block(BlockName.From("       Test block       "));
    block.Name.Value.ShouldBe("Test block");
  }

  [Fact]
  public void ProgramBlockMustHaveAName()
  {
    var program = new Program(ProgramName.From("Test program"));
    var action = () => program.AddBlock(BlockName.From(string.Empty));
    Should.Throw<Vogen.ValueObjectValidationException>(action);
  }

  [Fact]
  public void ProgramBlockNameMustNotExceedCharacterLimit()
  {
    var program = new Program(ProgramName.From("Test program"));
    var longBlockName = string.Concat(Enumerable.Repeat("I", BlockName.MaxLength + 1));
    var action = () => program.AddBlock(BlockName.From(longBlockName));
    Should.Throw<Vogen.ValueObjectValidationException>(action);
  }
}

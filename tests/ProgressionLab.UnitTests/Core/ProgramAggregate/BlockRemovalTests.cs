using ProgressionLab.Core.ProgramAggregate;

namespace ProgressionLab.UnitTests.Core.ProgramAggregate;

public class BlockRemovalTests
{
  [Fact]
  public void ProgramCanRemoveBlock()
  {
    var program = new Program(ProgramName.From("test prog"));
    var block = program.CreateBlock(BlockName.From("block 1"));
    program.RemoveBlock(block);
    program.GetBlocks().ShouldBeEmpty();
  }
  
  [Fact]
  public void ProgramCanRemoveBlockByBlockName()
  {
    var program = new Program(ProgramName.From("test prog"));
    program.CreateBlock(BlockName.From("block 1"));
    program.RemoveBlock(BlockName.From("block 1"));
    program.GetBlocks().ShouldBeEmpty();
  }

  [Fact]
  public void RemovingBlockThatDoesNotExistWillSkipAndContinue()
  {
    var program = new Program(ProgramName.From("test prog"));
    program.CreateBlock(BlockName.From("block 1"));
    program.RemoveBlock(BlockName.From("block 2"));
    program.GetBlocks().Count.ShouldBe(1);
  }

  [Fact]
  public void RemovingBlockIsCaseInsensitive()
  {
    var program = new Program(ProgramName.From("test prog"));
    program.CreateBlock(BlockName.From("block 1"));
    program.RemoveBlock(BlockName.From("BlOcK 1"));
    
    program.GetBlocks().ShouldBeEmpty();
  }
}

using ProgressionLab.Core.ProgramAggregate.Exceptions;

namespace ProgressionLab.Core.ProgramAggregate;

public class Program(ProgramName name) : EntityBase<Program, ProgramId>
{
  public ProgramName Name { get; private set;  } = name;
  private List<Block> Blocks { get; } = [];
  
  public Block CreateBlock(BlockName name)
  {
    var isDuplicate = Blocks.Any(b => b.Name == name);
    if (isDuplicate)
      throw new DuplicateBlockNameException();
    
    var block = new Block(name);
    Blocks.Add(block);
    return block;
  }

  public IReadOnlyList<Block> GetBlocks()
  {
    return Blocks.AsReadOnly();
  }
  
  public void RemoveBlock(Block block)
  {
    Blocks.Remove(block);
  }

  public void RemoveBlock(BlockName blockName)
  {
    var block = Blocks.SingleOrDefault(b => b.Name == blockName);
    if (block != null)
      Blocks.Remove(block);
  }
}

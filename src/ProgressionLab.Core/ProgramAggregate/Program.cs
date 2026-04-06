using ProgressionLab.Core.ProgramAggregate.Exceptions;

namespace ProgressionLab.Core.ProgramAggregate;

public class Program : EntityBase<Program, ProgramId>
{
  public ProgramName Name { get; private set;  }
  private List<Block> Blocks { get; } = [];

  private Program() { }
  
  public Program(ProgramName name) => Name = name;

  public Block CreateBlock(BlockName name)
  {
    var isDuplicate = Blocks.Any(b => b.Name == name);
    if (isDuplicate)
      throw new DuplicateBlockNameException();
    
    var block = new Block(name);
    Blocks.Add(block);
    return block;
  }

  public IReadOnlyList<Block> GetBlocks() => Blocks.AsReadOnly();

  public void RemoveBlock(Block block)
  {
    if (Blocks.Contains(block))
      Blocks.Remove(block);
  }

  public void RemoveBlock(BlockName blockName)
  {
    var block = Blocks.SingleOrDefault(b => b.Name == blockName);
    if (block != null)
      Blocks.Remove(block);
  }
}

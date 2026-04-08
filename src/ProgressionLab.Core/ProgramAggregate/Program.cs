using ProgressionLab.Core.ProgramAggregate.Exceptions;

namespace ProgressionLab.Core.ProgramAggregate;

public class Program : EntityBase<Program, ProgramId>
{
  private List<Block> Blocks { get; } = [];
  public ProgramName Name { get; private set;  }

  private Program() { }
  
  public Program(ProgramName name) => Name = name;

  public Block CreateBlock(BlockName name)
  {
    var isDuplicate = Blocks.Any(b => string.Equals(b.Name.Value, name.Value, StringComparison.OrdinalIgnoreCase));
    if (isDuplicate)
      throw new DuplicateBlockNameException();
    
    var block = new Block(name);
    Blocks.Add(block);
    return block;
  }

  public IReadOnlyList<Block> GetBlocks() => Blocks.AsReadOnly();

  public void RemoveBlock(Block block)
  {
    Blocks.Remove(block);
  }

  public void RemoveBlock(BlockName blockName)
  {
    var block = Blocks.SingleOrDefault(b => b.Name.Value.Equals(blockName.Value, StringComparison.OrdinalIgnoreCase));
    if (block != null)
      Blocks.Remove(block);
  }
}

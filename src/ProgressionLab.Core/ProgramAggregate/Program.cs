namespace ProgressionLab.Core.ProgramAggregate;

public class Program(ProgramName name) : EntityBase<Program, ProgramId>
{
  public ProgramName Name { get; private set;  } = name;
  private List<Block> Blocks { get; } = [];
  
  public Block AddBlock(BlockName name)
  {
    var block = new Block(name);
    Blocks.Add(block);
    return block;
  }

  public IReadOnlyList<Block> GetBlocks()
  {
    return Blocks.AsReadOnly();
  }
}

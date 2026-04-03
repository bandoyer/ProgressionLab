using ProgressionLab.Core.ProgramAggregate;

namespace ProgressionLab.UnitTests.Builders;

public class ProgramBuilder
{
  private string _name = "Test Program";
  private readonly List<(string name, int weeks)> _blocks = [];

  public ProgramBuilder WithName(string name)
  {
    _name = name;
    return this;
  }

  public ProgramBuilder WithBlock(string name = "Test Block", int weeks = 0)
  {
    _blocks.Add((name, weeks));
    return this;
  }

  public ProgramBuilder WithDefaultValues()
  {
    _name = "Test Program";
    _blocks.Clear();
    return this;
  }

  public Program Build()
  {
    var program = new Program(ProgramName.From(_name));

    foreach (var (name, weeks) in _blocks)
    {
      var block = program.AddBlock(BlockName.From(name));
      for (var i = 0; i < weeks; i++)
      {
        block.CreateWeek();
      }
    }

    return program;
  }
}

using ProgressionLab.Core.ProgramAggregate;
using ProgressionLab.UnitTests.Builders;

namespace ProgressionLab.UnitTests.Core.ProgramAggregate;

public class ProgramConstructorTests
{
  [Fact]
  public void ProgramMustHaveAName()
  {
    var action = () => new ProgramBuilder().WithName(string.Empty).Build();
    Should.Throw<Vogen.ValueObjectValidationException>(action);
  }

  [Fact]
  public void ProgramMustNotExceedCharacterLimit()
  {
    var longName = string.Concat(Enumerable.Repeat("I", ProgramName.MaxLength + 1));
    var action = () => new ProgramBuilder().WithName(longName).Build();
    Should.Throw<Vogen.ValueObjectValidationException>(action);
  }

  [Fact]
  public void ProgramNameMustWhenCreatedWillBeTrimmed()
  {
    var program = new ProgramBuilder().WithName("     Test program name       ").Build();
    program.Name.Value.ShouldBe("Test program name");
  }
}

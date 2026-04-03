using ProgressionLab.Core.ProgramAggregate;

namespace ProgressionLab.UnitTests.Core.ProgramAggregate;

public class ProgramConstructorTests
{
  [Fact]
  public void ProgramMustHaveAName()
  {
    var action = () => new Program(ProgramName.From(string.Empty));
    Should.Throw<Vogen.ValueObjectValidationException>(action);
  }

  [Fact]
  public void ProgramMustNotExceedCharacterLimit()
  {
    var longName = string.Concat(Enumerable.Repeat("I", ProgramName.MaxLength + 1));
    var action = () => new Program(ProgramName.From(longName));
    Should.Throw<Vogen.ValueObjectValidationException>(action);
  }

  [Fact]
  public void ProgramNameMustWhenCreatedWillBeTrimmed()
  {
    var program = new Program(ProgramName.From("     Test program name       "));
    program.Name.Value.ShouldBe("Test program name");
  }
}

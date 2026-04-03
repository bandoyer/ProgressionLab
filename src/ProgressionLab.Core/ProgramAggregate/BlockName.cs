using Vogen;

namespace ProgressionLab.Core.ProgramAggregate;

[ValueObject<string>]
public readonly partial struct BlockName
{
  public const int MaxLength = 255;

  private static string NormalizeInput(string input) => input.Trim();
  
  private static Validation Validate(in string name)
  {
    if (string.IsNullOrEmpty(name))
      return Validation.Invalid("Name cannot be empty");
    
    if (name.Length > MaxLength)
      return Validation.Invalid($"Name cannot be longer than {MaxLength} characters");
    
    return Validation.Ok;
  }
}

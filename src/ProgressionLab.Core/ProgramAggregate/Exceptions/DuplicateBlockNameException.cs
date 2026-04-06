namespace ProgressionLab.Core.ProgramAggregate.Exceptions;

public class DuplicateBlockNameException() 
  : DomainException("A block with this name already exists");

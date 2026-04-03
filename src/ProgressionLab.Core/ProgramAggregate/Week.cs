namespace ProgressionLab.Core.ProgramAggregate;

public class Week
{
  internal Week(WeekNumber weekNumber)
  {
    Number = weekNumber;
  }
  
  public WeekNumber Number { get; private set; }
}

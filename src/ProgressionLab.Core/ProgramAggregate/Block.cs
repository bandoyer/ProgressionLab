namespace ProgressionLab.Core.ProgramAggregate;

public class Block(BlockName name)
{
  public BlockName Name { get; private set; } = name;
  private List<Week> Weeks { get; } = [];

  public Week CreateWeek()
  {
    var weekNumber = WeekNumber.From(Weeks.Count + 1);
    var week = new Week(weekNumber);
    Weeks.Add(week);
    return week;
  }

  public IReadOnlyList<Week> GetWeeks()
  {
    return Weeks.AsReadOnly();
  }
}

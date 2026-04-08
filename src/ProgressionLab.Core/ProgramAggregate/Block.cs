namespace ProgressionLab.Core.ProgramAggregate;

public class Block
{
  private List<Week> Weeks { get; } = [];
  
  public BlockName Name { get; private set; }
  
  internal Block(BlockName name)
  {
    Name = name;
  }

  public Week CreateWeek()
  {
    var weekNumber = WeekNumber.From(Weeks.Count + 1);
    var week = new Week(weekNumber);
    Weeks.Add(week);
    return week;
  }

  public IReadOnlyList<Week> GetWeeks() => Weeks.AsReadOnly();

  public void RemoveWeek(Week week) => Weeks.Remove(week);

  public void RemoveWeek(WeekNumber weekNumber)
  {
    var week = Weeks.SingleOrDefault(w => w.Number == weekNumber);
    if (week != null)
      Weeks.Remove(week);
  }
}

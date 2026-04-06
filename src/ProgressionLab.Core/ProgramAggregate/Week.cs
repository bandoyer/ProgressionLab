namespace ProgressionLab.Core.ProgramAggregate;

public class Week
{
  internal Week(WeekNumber weekNumber)
  {
    Number = weekNumber;
  }
  
  public WeekNumber Number { get; private set; }
  private List<Slot> Slots = [];
  
  public Slot CreateSlot()
  {
    var slot = new Slot();
    Slots.Add(slot);
    return slot;
  }

  public IReadOnlyList<Slot> GetSlots()
  {
    return Slots.AsReadOnly();
  }
}

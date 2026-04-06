namespace ProgressionLab.Core.ProgramAggregate;

public class TrainingDay
{
  private List<Slot> Slots { get; } = [];
  public TrainingDayNumber Number { get; private set; }
  
  internal TrainingDay(TrainingDayNumber trainingDayNumber) 
    => Number = trainingDayNumber;

  public Slot CreateSlot()
  {
    var slot = new Slot();
    Slots.Add(slot);
    return slot;
  }

  public IReadOnlyList<Slot> GetSlots() => Slots.AsReadOnly();
}

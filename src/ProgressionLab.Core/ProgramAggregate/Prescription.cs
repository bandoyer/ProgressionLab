using ProgressionLab.Core.ValueObjects;

namespace ProgressionLab.Core.ProgramAggregate;

public class Prescription
{
  public Reps Reps { get; }
  public RPE Rpe { get; }
  public SetCount Count { get; }

  public Prescription(Reps reps, RPE rpe, SetCount count)
  {
    Reps = reps;
    Rpe = rpe;
    Count = count;
  }
}

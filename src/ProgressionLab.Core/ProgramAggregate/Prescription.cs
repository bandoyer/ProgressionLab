using ProgressionLab.Core.ValueObjects;

namespace ProgressionLab.Core.ProgramAggregate;

public sealed record Prescription
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

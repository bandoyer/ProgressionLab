namespace ProgressionLab.Core.ProgramAggregate;

public sealed record Prescription
{
  public Reps Reps { get; }
  public RPE.RPE Rpe { get; }
  public SetCount Count { get; }
  public PercentageOfOneRepMax? PercentageOfOneRepMax { get; }

  public Prescription(Reps reps, RPE.RPE rpe, SetCount count)
  {
    Reps = reps;
    Rpe = rpe;
    Count = count;
  }
  
  public Prescription(Reps reps, RPE.RPE rpe, SetCount count, PercentageOfOneRepMax percentageOfOneRepMax)
  {
    Reps = reps;
    Rpe = rpe;
    Count = count;
    PercentageOfOneRepMax = percentageOfOneRepMax;
  }
}

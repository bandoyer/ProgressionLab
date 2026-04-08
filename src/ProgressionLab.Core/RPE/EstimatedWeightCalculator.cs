using ProgressionLab.Core.ProgramAggregate;

namespace ProgressionLab.Core.RPE;

public static class EstimatedWeightCalculator
{
  public static decimal GetWeight(Reps repCount, RPE rpe, Weight oneRepMax)
  {
    return RpePercentages.Get(repCount, rpe) * oneRepMax.Value;
  }
  
  public static decimal GetOneRepMax(Weight knownWeight, Reps reps, RPE rpe)
  {
    var rpePercentage = RpePercentages.Get(reps, rpe);
    return Math.Round(knownWeight.Value / rpePercentage, 1);
  }
}

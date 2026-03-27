namespace ProgressionLab.Core.ValueObjects;

public static class EstimatedWeightCalculator
{
  public static decimal GetWeight(int repCount, RPE rpe, int oneRepMax)
  {
    return RpePercentages.Get(repCount, rpe) * oneRepMax;
  }
  
  public static decimal GetOneRepMax(decimal knownWeight, int reps, RPE rpe)
  {
    var rpePercentage = RpePercentages.Get(reps, rpe);
    return Math.Round(knownWeight / rpePercentage, 1);
  }
}

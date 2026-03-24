using ProgressionLab.Core.Services;
using ProgressionLab.Core.ValueObjects;

namespace ProgressionLab.UnitTests.Core.ValueObjects;

public class RpeCalculationTests
{
  [Fact]
  public void GivenOneRepMaxItWillCalculateRpe10()
  {
    // Given one rep max, to calculate RPE 10, it will return the 1RM
    var oneRepMax = 100;
    
    // The calculator needs a 1RM to work, force it
    var calculator = new EstimatedWeightCalculator(oneRepMax);
    
    var weightAtRpe10 = calculator.GetEstimatedWeight(1, RPE.From(10));
    
    weightAtRpe10.ShouldBe(100);
  }
  
  [Fact]
  public void GivenOneRepMaxItWillCalculateRpe9_5()
  {
    // Given one rep max, to calculate RPE 10, it will return the 1RM
    var oneRepMax = 100;
    
    // The calculator needs a 1RM to work, force it
    var calculator = new EstimatedWeightCalculator(oneRepMax);
    
    var weightAtRpe9_5 = calculator.GetEstimatedWeight(1, RPE.From(9.5m));
    
    weightAtRpe9_5.ShouldBe(97.8m);
  }
  
  public static TheoryData<int, RPE, decimal> RepToRpeData => new()
  {
    { 1,  RPE.From(10m), 100m  },
    { 2,  RPE.From(9.5m), 93.9m },
    { 3,  RPE.From(9m), 89.2m   },
    { 4,  RPE.From(8.5m), 85m },
    { 5,  RPE.From(8m), 81.1m   },
    { 6,  RPE.From(7.5m), 77.4m },
    { 7,  RPE.From(7m), 73.9m   },
    { 8,  RPE.From(6.5m), 69.4m },
    { 9,  RPE.From(6m), 65.3m   },
    { 10, RPE.From(6.5m), 64m },
    { 11, RPE.From(7m), 62.6m   },
    { 12, RPE.From(7.5m), 61.3m },
  };
  
  [Theory]
  [MemberData(nameof(RepToRpeData))]
  public void GivenOneRepMaxItWillCalculateRpe(int repCount, RPE rpe, decimal expectedWeight)
  {
    var calculator = new EstimatedWeightCalculator(100);
    var weight = calculator.GetEstimatedWeight(repCount, rpe);                                                                                                                                        
    weight.ShouldBe(expectedWeight);
  }
}

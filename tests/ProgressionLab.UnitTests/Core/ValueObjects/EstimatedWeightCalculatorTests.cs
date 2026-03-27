using ProgressionLab.Core.Services;
using ProgressionLab.Core.ValueObjects;

namespace ProgressionLab.UnitTests.Core.ValueObjects;

public class EstimatedWeightCalculatorTests
{
  [Fact]
  public void GivenOneRepMaxItWillCalculateRpe10()
  {
    var oneRepMax = 100;
    var weightAtRpe10 = EstimatedWeightCalculator.GetWeight(1, RPE.From(10), oneRepMax);
    weightAtRpe10.ShouldBe(100);
  }
  
  [Fact]
  public void GivenOneRepMaxItWillCalculateRpe9_5()
  {
    var oneRepMax = 100;
    var weightAtRpe9_5 = EstimatedWeightCalculator.GetWeight(1, RPE.From(9.5m), oneRepMax);
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
    var weight = EstimatedWeightCalculator.GetWeight(repCount, rpe, 100);                                                                                                                                        
    weight.ShouldBe(expectedWeight);
  }
  
  [Fact]
  public void GivenRpeTenAtOneRepWillReturnOneRepMax()
  {
    var weight = EstimatedWeightCalculator.GetOneRepMax(100m, 1, RPE.From(10));
    weight.ShouldBe(100);
  }
  
  [Fact]
  public void GivenRpeEightAtOneRepWillReturnOneRepMaxRoundedToNearestDecimal()
  {
    var weight = EstimatedWeightCalculator.GetOneRepMax(100m, 1, RPE.From(8));
    weight.ShouldBe(108.5m);
  }

  [Fact]
  public void GivenRpeNineAtTwoRepsReturnOneRepMaxRoundedToNearestDecimal()
  {
    var weight = EstimatedWeightCalculator.GetOneRepMax(100, 2, RPE.From(9));
    weight.ShouldBe(108.5m);
  }
}

using ProgressionLab.Core.ProgramAggregate;
using ProgressionLab.Core.RPE;
using Reps = ProgressionLab.Core.ProgramAggregate.Reps;

namespace ProgressionLab.UnitTests.Core.RPETests;

public class EstimatedWeightCalculatorTests
{
  [Fact]
  public void GivenOneRepMaxItWillCalculateRpe10()
  {
    var oneRepMax = Weight.From(100);
    var weightAtRpe10 = EstimatedWeightCalculator.GetWeight(Reps.From(1), ProgressionLab.Core.RPE.RPE.From(10), oneRepMax);
    weightAtRpe10.ShouldBe(100);
  }
  
  [Fact]
  public void GivenOneRepMaxItWillCalculateRpe9_5()
  {
    var oneRepMax = Weight.From(100);
    var weightAtRpe9_5 = EstimatedWeightCalculator.GetWeight(Reps.From(1), ProgressionLab.Core.RPE.RPE.From(9.5m), oneRepMax);
    weightAtRpe9_5.ShouldBe(97.8m);
  }
  
  public static TheoryData<Reps, ProgressionLab.Core.RPE.RPE, decimal> RepToRpeData => new()
  {
    { Reps.From(1),  ProgressionLab.Core.RPE.RPE.From(10m), 100m  },
    { Reps.From(2),  ProgressionLab.Core.RPE.RPE.From(9.5m), 93.9m },
    { Reps.From(3),  ProgressionLab.Core.RPE.RPE.From(9m), 89.2m   },
    { Reps.From(4),  ProgressionLab.Core.RPE.RPE.From(8.5m), 85m },
    { Reps.From(5),  ProgressionLab.Core.RPE.RPE.From(8m), 81.1m   },
    { Reps.From(6),  ProgressionLab.Core.RPE.RPE.From(7.5m), 77.4m },
    { Reps.From(7),  ProgressionLab.Core.RPE.RPE.From(7m), 73.9m   },
    { Reps.From(8),  ProgressionLab.Core.RPE.RPE.From(6.5m), 69.4m },
    { Reps.From(9),  ProgressionLab.Core.RPE.RPE.From(6m), 65.3m   },
    { Reps.From(10), ProgressionLab.Core.RPE.RPE.From(6.5m), 64m },
    { Reps.From(11), ProgressionLab.Core.RPE.RPE.From(7m), 62.6m   },
    { Reps.From(12), ProgressionLab.Core.RPE.RPE.From(7.5m), 61.3m },
  };
  
  [Theory]
  [MemberData(nameof(RepToRpeData))]
  public void GivenOneRepMaxItWillCalculateRpe(Reps repCount, ProgressionLab.Core.RPE.RPE rpe, decimal expectedWeight)
  {
    var weight = EstimatedWeightCalculator.GetWeight(repCount, rpe, Weight.From(100));                                                                                                                                        
    weight.ShouldBe(expectedWeight);
  }
  
  [Fact]
  public void GivenRpeTenAtOneRepWillReturnOneRepMax()
  {
    var weight = EstimatedWeightCalculator.GetOneRepMax(Weight.From(100), Reps.From(1), ProgressionLab.Core.RPE.RPE.From(10));
    weight.ShouldBe(100);
  }
  
  [Fact]
  public void GivenRpeEightAtOneRepWillReturnOneRepMaxRoundedToNearestDecimal()
  {
    var weight = EstimatedWeightCalculator.GetOneRepMax(Weight.From(100), Reps.From(1), ProgressionLab.Core.RPE.RPE.From(8));
    weight.ShouldBe(108.5m);
  }

  [Fact]
  public void GivenRpeNineAtTwoRepsReturnOneRepMaxRoundedToNearestDecimal()
  {
    var weight = EstimatedWeightCalculator.GetOneRepMax(Weight.From(100), Reps.From(2), ProgressionLab.Core.RPE.RPE.From(9));
    weight.ShouldBe(108.5m);
  }
}

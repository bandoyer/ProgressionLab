namespace ProgressionLab.Core.ProgramAggregate;

public class Week
{
  private List<TrainingDay> TrainingDays = [];

  public WeekNumber Number { get; private set; }
  
  internal Week(WeekNumber weekNumber)
  {
    Number = weekNumber;
  }

  public TrainingDay CreateTrainingDay()
  {
    var trainingDayNumber = TrainingDayNumber.From(TrainingDays.Count + 1);
    var trainingDay = new TrainingDay(trainingDayNumber);
    TrainingDays.Add(trainingDay);
    return trainingDay;
  }

  public IReadOnlyList<TrainingDay> GetTrainingDays()
  {
    return TrainingDays.AsReadOnly();
  }
}

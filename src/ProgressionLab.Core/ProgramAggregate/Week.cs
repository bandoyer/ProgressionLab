namespace ProgressionLab.Core.ProgramAggregate;

public class Week
{
  internal Week(WeekNumber weekNumber)
  {
    Number = weekNumber;
  }
  
  public WeekNumber Number { get; private set; }
  private List<TrainingDay> TrainingDays = [];

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

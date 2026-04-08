namespace ProgressionLab.Core.ProgramAggregate;

public class Slot
{
  private List<Prescription> Prescriptions { get; } = [];
  
  public void SetPrescription(Prescription prescription)
  {
    Prescriptions.Add(prescription);
  }

  public IReadOnlyList<Prescription> GetPrescriptions()
  {
    return Prescriptions.AsReadOnly();
  }
}

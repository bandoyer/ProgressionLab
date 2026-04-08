namespace ProgressionLab.Core.ProgramAggregate;

public class Slot
{
  public Prescription? Prescription { get; private set; }
  
  public void SetPrescription(Prescription prescription)
  {
    Prescription = prescription;
  }
}

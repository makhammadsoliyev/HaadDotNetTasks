namespace HospitalCRM;

public class HospitalService : IHospitalService
{
    private List<Patient> patients;

    public HospitalService()
    {
        patients = new List<Patient>();
    }

    public void CreatePatient(Patient patient)
    {
        patients.Add(patient);
        Console.WriteLine("Successfully added...");
    }

    public void UpdatePatient(Patient patient, int id)
    {
        int index = patients.FindIndex(p => p.Id == id);
        if (index == -1)
        {
            Console.WriteLine("Patient was not found...");
        }
        else
        {
            patient.Id = id;
            patient.RegisteredTime = patients[index].RegisteredTime;
            patients[index] = patient;
            Console.WriteLine("Successfully updated...");
        }
    }

    public bool DeletePatient(int id)
    {
        return patients.Remove(GetPatient(id));
    }

    public List<Patient> GetAllPatients()
    {
        return patients;
    }

    public Patient GetPatient(int id)
    {
        return patients.FirstOrDefault(p => p.Id == id);
    }

}

namespace HospitalCRM;

public interface IHospitalService
{
    void CreatePatient(Patient patient);
    Patient GetPatient(int id);
    //void GetPatient(int id);
    void UpdatePatient(Patient patient, int id);
    bool DeletePatient(int id);
    List<Patient> GetAllPatients();
}

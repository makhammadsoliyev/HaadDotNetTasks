using Anjeer.Models;

namespace Anjeer.Interfaces;

public interface IEmployeeService
{
    void Create(Employee employee);
    void Update(int id, Employee employee);
    bool Delete(int id);
    Employee GetById(int id);
    Employee GetByPassportNumber(string passportNumber);
    List<Employee> GetAllPosition(Position position);
    List<Employee> GetAll();
}

using Anjeer.Interfaces;
using Anjeer.Models;

namespace Anjeer.Services;

public class EmployeeService : IEmployeeService
{
    #region Private Field
    private List<Employee> employees;
    #endregion
    #region CTOR
    public EmployeeService()
    {
        employees = new List<Employee>();
    }
    #endregion
    #region Methods
    public void Create(Employee employee)
    {
        employees.Add(employee);
    }

    public bool Delete(int id)
        => employees.Remove(GetById(id));

    public List<Employee> GetAll()
        => employees;

    public List<Employee> GetAllPosition(Position position)
        => employees.FindAll(employee => employee.Position.Equals(position));

    public Employee GetById(int id)
        => employees.FirstOrDefault(employee => employee.Id.Equals(id));

    public Employee GetByPassportNumber(string passportNumber)
        => employees.FirstOrDefault(employee => employee.PassportNumber.Equals(passportNumber));
    

    public void Update(int id, Employee employee)
    {
        var employeeToUpdate = GetById(id);
        employeeToUpdate.Id = id;
        employeeToUpdate.LastName = employee.LastName;
        employeeToUpdate.Position = employee.Position;
        employeeToUpdate.FirstName = employee.FirstName;
        employeeToUpdate.PassportNumber = employee.PassportNumber;
    }
    #endregion
}

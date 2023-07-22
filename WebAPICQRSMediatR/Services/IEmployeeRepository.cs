using WebAPICQRSMediatR.Models;

namespace WebAPICQRSMediatR.Services
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeeList();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> AddEmployee(Employee employee);
        Task<int> UpdateEmployee(Employee employee);
        Task<int> DeleteEmployee(int id);
    }
}
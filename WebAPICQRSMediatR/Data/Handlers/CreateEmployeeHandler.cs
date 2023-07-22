using MediatR;
using WebAPICQRSMediatR.Data.Command;
using WebAPICQRSMediatR.Models;
using WebAPICQRSMediatR.Services;

namespace WebAPICQRSMediatR.Data.Handlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                Name = request.Name,
                Address = request.Address,
                Email = request.Email,
                Phone = request.Phone,
            };

            return await _employeeRepository.AddEmployee(employee);
        }
    }
}

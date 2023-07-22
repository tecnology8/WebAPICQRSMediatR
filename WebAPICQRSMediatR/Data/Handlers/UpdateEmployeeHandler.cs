using MediatR;
using WebAPICQRSMediatR.Data.Command;
using WebAPICQRSMediatR.Services;

namespace WebAPICQRSMediatR.Data.Handlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<int> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeById(request.Id);
            if(employee == null) { return default; } 
            employee.Name = request.Name;
            employee.Address = request.Address;
            employee.Email = request.Email;
            employee.Phone = request.Phone;

            return await _employeeRepository.UpdateEmployee(employee);
        }
    }
}

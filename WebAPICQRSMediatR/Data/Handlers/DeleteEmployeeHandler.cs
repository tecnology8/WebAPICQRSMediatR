using MediatR;
using WebAPICQRSMediatR.Data.Command;
using WebAPICQRSMediatR.Services;

namespace WebAPICQRSMediatR.Data.Handlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeById(request.Id);
            if (employee == null) return default;
            return await _employeeRepository.DeleteEmployee(employee.Id);
        }
    }
}

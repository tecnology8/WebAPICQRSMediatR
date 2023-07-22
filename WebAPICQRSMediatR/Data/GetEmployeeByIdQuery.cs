using MediatR;
using WebAPICQRSMediatR.Models;

namespace WebAPICQRSMediatR.Data
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int Id { get; set; }
    }
}
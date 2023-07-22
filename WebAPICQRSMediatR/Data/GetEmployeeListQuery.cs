using MediatR;
using WebAPICQRSMediatR.Models;

namespace WebAPICQRSMediatR.Data
{
    public class GetEmployeeListQuery : IRequest<List<Employee>>
    {

    }
}

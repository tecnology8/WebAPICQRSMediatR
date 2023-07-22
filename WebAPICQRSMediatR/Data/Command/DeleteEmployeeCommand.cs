using MediatR;

namespace WebAPICQRSMediatR.Data.Command
{
    public class DeleteEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
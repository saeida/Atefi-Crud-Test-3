using Application.Commands;
using Core.Interface.Command;
using Core.Interface.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CommandHandler
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, String>
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;
        private readonly ICustomerQueryRepository _customerQueryRepository;
        public DeleteCustomerHandler(ICustomerCommandRepository customerRepository, ICustomerQueryRepository customerQueryRepository)
        {
            _customerCommandRepository = customerRepository;
            _customerQueryRepository = customerQueryRepository;
        }

        public async Task<string> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cm = await _customerQueryRepository.GetByIdAsync(request.Id);

                await _customerCommandRepository.DeleteAsync(cm);
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return "Customer Successfully deleted!";
        }
    }
}

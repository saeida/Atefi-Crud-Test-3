using Application.Commands;
using Core.Interface.Command;
using Core.Interface.Query;
using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CommandHandler
{
    public class EditCustomerHandler : IRequestHandler<EditCustomerCommand, CustomerModel>
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;
        private readonly ICustomerQueryRepository _customerQueryRepository;
        public EditCustomerHandler(ICustomerCommandRepository customerRepository, ICustomerQueryRepository customerQueryRepository)
        {
            _customerCommandRepository = customerRepository;
            _customerQueryRepository = customerQueryRepository;
        }
        public async Task<CustomerModel> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
        {


            CustomerModel cm = new CustomerModel();
            cm.Id = request.Id;
            cm.Firstname = request.Firstname;
            cm.Firstname = request.Firstname;
            cm.Lastname = request.Lastname;
            cm.PhoneNumber = request.PhoneNumber;
            cm.DateOfBirth = request.DateOfBirth;
            cm.BankAccountNumber = request.BankAccountNumber;
            cm.Email = request.Email;

            try
            {
                await _customerCommandRepository.UpdateAsync(cm);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var result = await _customerQueryRepository.GetByIdAsync(request.Id);        

            return result;
        }
    }
}

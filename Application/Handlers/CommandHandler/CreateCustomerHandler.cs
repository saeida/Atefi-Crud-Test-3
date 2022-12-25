using Application.Commands;
using Core.Interface.Command;
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
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerModel>
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;
        public CreateCustomerHandler(ICustomerCommandRepository customerCommandRepository)
        {
            _customerCommandRepository = customerCommandRepository;
        }
        public async Task<CustomerModel> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            CustomerModel cm = new CustomerModel();
            cm.Firstname = request.Firstname;
            cm.Firstname = request.Firstname;
            cm.Lastname = request.Lastname;
            cm.PhoneNumber = request.PhoneNumber;
            cm.DateOfBirth = request.DateOfBirth;
            cm.BankAccountNumber = request.BankAccountNumber;
            cm.Email = request.Email;   

            var newCustomer = await _customerCommandRepository.AddAsync(cm);


            
           newCustomer.Firstname = request.Firstname;
           newCustomer.Firstname = request.Firstname;
           newCustomer.Lastname = request.Lastname;
           newCustomer.PhoneNumber = request.PhoneNumber;
           newCustomer.DateOfBirth = request.DateOfBirth;
           newCustomer.BankAccountNumber = request.BankAccountNumber;
            newCustomer.Email = request.Email;


            return newCustomer;
        }



    }
}

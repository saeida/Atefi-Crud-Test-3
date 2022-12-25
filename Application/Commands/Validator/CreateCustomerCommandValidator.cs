using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Validator
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(customer => customer.Firstname).NotEmpty();
            RuleFor(customer => customer.Lastname).NotEmpty();
        //    RuleFor(customer => customer.Email).NotEmpty().Must(password => hasValidPassword(password));
        }


        
    }
}

using Core.Interface.Command;
using Core.Model;
using Infrastructure.Persistence.Entities;
using Infrastructure.Repository.Command.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Command
{
    public class CustomerCommandRepository : CommandRepository<CustomerModel>, ICustomerCommandRepository
    {
        public CustomerCommandRepository(CRUDTESTContext context) : base(context)
        {

        }
    }
}

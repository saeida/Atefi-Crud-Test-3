﻿using Core.Interface.Command.Generic;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Command
{
    public interface ICustomerCommandRepository : ICommandRepository<CustomerModel>
    {

    }
}

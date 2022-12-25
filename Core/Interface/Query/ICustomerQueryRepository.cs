using Core.Interface.Query.Generic;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Query
{
    public interface ICustomerQueryRepository : IQueryRepository<CustomerModel>
    {
        
        Task<List<CustomerModel>> GetAllAsync();
        Task<CustomerModel> GetByIdAsync(Int64 id);
     
    }
}

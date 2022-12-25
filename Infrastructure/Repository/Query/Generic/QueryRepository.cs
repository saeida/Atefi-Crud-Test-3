using Core.Interface.Query.Generic;
using Infrastructure.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Query.Generic
{
    public class QueryRepository<T> : IQueryRepository<T> where T : class
    {

        public readonly CRUDTESTContext _dbContext;
        public QueryRepository(CRUDTESTContext dbContext)           
        {
            _dbContext = dbContext;
        }
    }
}

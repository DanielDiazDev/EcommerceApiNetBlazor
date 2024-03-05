using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceNetBlazor.Data.Repositories.Contracts
{
    public interface IGenericRepository<T>
    {
        Task<T> Create(T entity);
        IQueryable<T> Consult(Expression<Func<T, bool>>? filter = null);
        Task<bool> Edit(T entity);
        Task<bool> Delete(T entity);
    }
}

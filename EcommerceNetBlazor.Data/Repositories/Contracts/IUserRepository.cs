using EcommerceNetBlazor.Model;
using System.Linq.Expressions;

namespace EcommerceNetBlazor.Data.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        IQueryable<User> Consult(Expression<Func<User, bool>>? filter = null);
        Task<bool> Edit(User user);
        Task<bool> Delete(User user);
    }
}

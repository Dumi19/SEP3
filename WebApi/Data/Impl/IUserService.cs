using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Data.Impl
{
    public interface IUserService
    {
        Task<IList<User>> getUsersAsync();
    }
}
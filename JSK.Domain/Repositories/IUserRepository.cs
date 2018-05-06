using JSK.Domain.Entities;
using System.Threading.Tasks;

namespace JSK.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmail(string email);
    }
}

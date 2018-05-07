using JSK.Domain.Entities;
using JSK.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JSK.Data.EntityFramework.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        internal UserRepository(Model model) : base(model)
        {

        }

        public Task<User> GetByEmail(string email)
        {
            return Set.FirstOrDefaultAsync(n => n.Email == email);
        }
    }
}

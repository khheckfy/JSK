using JSK.Domain.Entities;
using JSK.Domain.Repositories;

namespace JSK.Data.EntityFramework.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        internal UserRepository(Model model) : base(model)
        {

        }
    }
}

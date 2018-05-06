using JSK.Domain.Entities;
using JSK.Domain.Repositories;

namespace JSK.Data.EntityFramework.Repositories
{
    internal class UserTestAnswerRepository : Repository<UserTestAnswer>, IUserTestAnswerRepository
    {
        internal UserTestAnswerRepository(Model model) : base(model)
        {

        }
    }
}

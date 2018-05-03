using JSK.Domain.Entities;
using JSK.Domain.Repositories;

namespace JSK.Data.EntityFramework.Repositories
{
    internal class TestRepository : Repository<Test>, ITestRepository
    {
        internal TestRepository(Model context)
            : base(context)
        {
        }
    }
}

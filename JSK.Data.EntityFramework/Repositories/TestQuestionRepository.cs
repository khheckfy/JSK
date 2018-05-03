using JSK.Domain.Entities;
using JSK.Domain.Repositories;

namespace JSK.Data.EntityFramework.Repositories
{
    internal class TestQuestionRepository : Repository<TestQuestion>, ITestQuestionRepository
    {
        internal TestQuestionRepository(Model context)
            : base(context)
        {
        }
    }
}

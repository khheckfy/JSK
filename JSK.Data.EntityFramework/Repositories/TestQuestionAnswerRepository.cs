using JSK.Domain.Entities;
using JSK.Domain.Repositories;

namespace JSK.Data.EntityFramework.Repositories
{
    internal class TestQuestionAnswerRepository : Repository<TestQuestionAnswer>, ITestQuestionAnswerRepository
    {
        internal TestQuestionAnswerRepository(Model context)
            : base(context)
        {
        }
    }
}

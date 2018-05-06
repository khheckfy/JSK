using JSK.Domain.Entities;
using JSK.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JSK.Data.EntityFramework.Repositories
{
    internal class TestRepository : Repository<Test>, ITestRepository
    {
        internal TestRepository(Model context)
            : base(context)
        {
        }

        public async Task<Test> GetFullItem(int testId)
        {
            return await Set
                    .Include(test => test.TestQuestions)
                    .ThenInclude(test => test.TestQuestionAnswers)
                    .FirstOrDefaultAsync(t => t.TestId == testId);
        }
    }
}

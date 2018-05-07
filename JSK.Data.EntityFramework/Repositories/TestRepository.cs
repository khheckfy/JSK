using JSK.Domain.Entities;
using JSK.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSK.Data.EntityFramework.Repositories
{
    internal class TestRepository : Repository<Test>, ITestRepository
    {
        private readonly Model context;
        internal TestRepository(Model context)
            : base(context)
        {
            this.context = context;
        }

        public Task<List<Test>> GetActiveTestsAsync()
        {
            return Set.Where(n => n.IsActive).ToListAsync();
        }

        public Task<Test> GetFullItem(int testId)
        {
            return Set
                    .Include(test => test.TestQuestions)
                    .ThenInclude(test => test.TestQuestionAnswers)
                    .FirstOrDefaultAsync(t => t.TestId == testId);
        }
    }
}

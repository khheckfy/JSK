using JSK.Domain.Entities;
using JSK.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSK.Data.EntityFramework.Repositories
{
    internal class TestQuestionRepository : Repository<TestQuestion>, ITestQuestionRepository
    {
        internal TestQuestionRepository(Model context)
            : base(context)
        {
        }

        public Task<List<TestQuestion>> GetTestQuestionsByTest(Guid userTestId)
        {
            return Set
                .Where(n => n.UserTestAnswers.Any(a => a.UserTestId == userTestId))
                .Distinct()
                .ToListAsync();

        }
    }
}

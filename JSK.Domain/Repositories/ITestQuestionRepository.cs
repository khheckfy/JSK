using JSK.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSK.Domain.Repositories
{
    public interface ITestQuestionRepository : IRepository<TestQuestion>
    {
        Task<List<TestQuestion>> GetTestQuestionsByTest(Guid userTestId);
    }
}

using JSK.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSK.Domain.Repositories
{
    public interface ITestRepository : IRepository<Test>
    {
        Task<List<Test>> GetActiveTestsAsync();
        Task<Test> GetFullItem(int testId);
    }
}

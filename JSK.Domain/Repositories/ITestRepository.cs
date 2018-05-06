using JSK.Domain.Entities;
using System.Threading.Tasks;

namespace JSK.Domain.Repositories
{
    public interface ITestRepository : IRepository<Test>
    {
        Task<Test> GetFullItem(int testId);
    }
}

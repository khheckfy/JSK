using JSK.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JSK.Domain.Repositories
{
    public interface IUserTestRepository : IRepository<UserTest>
    {
        Task<Test> GetTest(Guid userTestId);
        IQueryable SelectResults();
        Task<UserTest> GetInfoResult(Guid id);
    }
}

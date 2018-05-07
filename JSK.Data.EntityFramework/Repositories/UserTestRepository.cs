using JSK.Domain.Entities;
using JSK.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSK.Data.EntityFramework.Repositories
{
    internal class UserTestRepository : Repository<UserTest>, IUserTestRepository
    {
        private readonly Model context;
        internal UserTestRepository(Model model) : base(model)
        {
            context = model;
        }

        public Task<Test> GetTest(Guid userTestId)
        {
            return Set
                .Include(n => n.Test)
                .Where(n => n.UserTestId == userTestId)
                .Select(n => n.Test).FirstOrDefaultAsync();
        }

        public IQueryable SelectResults()
        {
            var query = from ut in Set
                        join u in context.Users on ut.UserId equals u.UserId
                        join t in context.Tests on ut.TestId equals t.TestId
                        select new
                        {
                            ut.UserTestId,
                            UserName = u.Name,
                            TestName = t.Name,
                            u.Email,
                            ut.CreatedOn
                        };

            return query;
        }
    }
}

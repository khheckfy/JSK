using JSK.Domain.Entities;
using JSK.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace JSK.Data.EntityFramework.Repositories
{
    internal class UserTestRepository : Repository<UserTest>, IUserTestRepository
    {
        internal UserTestRepository(Model model) : base(model)
        { }
    }
}

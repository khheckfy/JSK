using JSK.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JSK.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        #region Properties

        ITestRepository TestRepository { get; }
        ITestQuestionAnswerRepository TestQuestionAnswerRepository { get; }
        ITestQuestionRepository TestQuestionRepository { get; }
        IUserRepository UserRepository { get; }
        IUserTestAnswerRepository UserTestAnswerRepository { get; }

        #endregion

        #region Methods
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        #endregion
    }
}

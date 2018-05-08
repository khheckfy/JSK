using JSK.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JSK.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        #region Properties

        /// <summary>
        /// Repo for tests
        /// </summary>
        ITestRepository TestRepository { get; }
        /// <summary>
        /// Repo for anwers of question
        /// </summary>
        ITestQuestionAnswerRepository TestQuestionAnswerRepository { get; }
        /// <summary>
        /// Repo for questions
        /// </summary>
        ITestQuestionRepository TestQuestionRepository { get; }
        /// <summary>
        /// Repo for users
        /// </summary>
        IUserRepository UserRepository { get; }
        /// <summary>
        /// repo for answers
        /// </summary>
        IUserTestAnswerRepository UserTestAnswerRepository { get; }
        /// <summary>
        /// Repo foruser test
        /// </summary>
        IUserTestRepository UserTestRepository { get; }

        #endregion

        #region Methods
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        #endregion
    }
}

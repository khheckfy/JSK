using JSK.Data.EntityFramework.Repositories;
using JSK.Domain;
using JSK.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace JSK.Data.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        private readonly Model _context;

        private ITestRepository _testRepository;
        private ITestQuestionAnswerRepository _testQuestionAnswerRepository;
        private ITestQuestionRepository _testQuestionRepository;
        private IUserRepository _userRepository;
        private IUserTestAnswerRepository _userTestAnswerRepository;

        #endregion

        #region Constructors

        public UnitOfWork(string connectionString)
        {
            _context = new Model(connectionString);
        }

        #endregion

        #region IUnitOfWork Members

        public IUserTestAnswerRepository UserTestAnswerRepository
        {
            get { return _userTestAnswerRepository ?? (_userTestAnswerRepository = new UserTestAnswerRepository(_context)); }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_context)); }
        }

        public ITestRepository TestRepository
        {
            get { return _testRepository ?? (_testRepository = new TestRepository(_context)); }
        }

        public ITestQuestionAnswerRepository TestQuestionAnswerRepository
        {
            get { return _testQuestionAnswerRepository ?? (_testQuestionAnswerRepository = new TestQuestionAnswerRepository(_context)); }
        }

        public ITestQuestionRepository TestQuestionRepository
        {
            get { return _testQuestionRepository ?? (_testQuestionRepository = new TestQuestionRepository(_context)); }
        }


        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        #endregion

        #region IDisposable Members

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
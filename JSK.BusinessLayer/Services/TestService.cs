using JSK.BusinessLayer.Interfaces;
using JSK.Domain;

namespace JSK.BusinessLayer.Services
{
    public class TestService : ITestService
    {
        private readonly IUnitOfWork DB;

        public TestService(IUnitOfWork db)
        {
            DB = db;
        }

        public void Test()
        {
            var list = DB.TestRepository.GetAll();
            foreach(var l in list)
            {

            }
        }
    }
}

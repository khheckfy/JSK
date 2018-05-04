using JSK.BusinessLayer.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSK.BusinessLayer.Interfaces
{
    public interface ITestService
    {
        Task<List<TestDTO>> Test_List();
    }
}

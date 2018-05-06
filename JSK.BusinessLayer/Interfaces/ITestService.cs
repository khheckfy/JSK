using JSK.BusinessLayer.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSK.BusinessLayer.Interfaces
{
    public interface ITestService
    {
        Task<List<TestDTO>> Test_ListAsync();
        Task Test_SaveAsync(TestDTO test);
        Task<TestDTO> Test_GetAsync(int id);
        Task Test_RemoveAsync(int id);

        Task Answer_RemoveAsync(int id);
        Task<int> Answer_AddAsync(TestQuestionAnswerDTO answer);
        Task Answer_IsCorrect(int id);
    }
}

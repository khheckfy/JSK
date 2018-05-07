using JSK.BusinessLayer.DTO;
using JSK.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSK.BusinessLayer.Interfaces
{
    public interface ITestService
    {
        Task<List<TestDTO>> Test_ListAsync();
        Task<int> Test_SaveAsync(TestDTO test);
        Task<TestDTO> Test_GetAsync(int id, bool isFull = false, bool isOnlActiveRecords = true);
        Task<TestDTO> Test_GetAsync(Guid userTestId);
        Task Test_RemoveAsync(int id);

        Task Answer_RemoveAsync(int id);
        Task<int> Answer_AddAsync(TestQuestionAnswerDTO answer);
        Task Answer_IsCorrect(int id);

        Task<TestItemModel> GetTestItemModelAsync(Guid id);
        Task<List<TestResultDTO>> ResultList();
        Task<UserTestDTO> GetInfoResult(Guid id);
    }
}

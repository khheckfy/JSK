using JSK.BusinessLayer.DTO;
using JSK.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSK.BusinessLayer.Interfaces
{
    public interface ITestService
    {
        /// <summary>
        /// Get all tests
        /// </summary>
        /// <returns></returns>
        Task<List<TestDTO>> Test_ListAsync();
        /// <summary>
        /// Save test
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        Task<int> Test_SaveAsync(TestDTO test);
        /// <summary>
        /// Get one test
        /// </summary>
        /// <param name="id">id of test</param>
        /// <param name="isFull">include sub entities</param>
        /// <param name="isOnlActiveRecords">only active questions and answers</param>
        /// <returns></returns>
        Task<TestDTO> Test_GetAsync(int id, bool isFull = false, bool isOnlActiveRecords = true);
        /// <summary>
        /// Get one test by user test id
        /// </summary>
        /// <param name="userTestId"></param>
        /// <returns></returns>
        Task<TestDTO> Test_GetAsync(Guid userTestId);
        /// <summary>
        /// set inactive for test
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Test_RemoveAsync(int id);
        /// <summary>
        /// set inactive answer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Answer_RemoveAsync(int id);
        /// <summary>
        /// Create answer
        /// </summary>
        /// <param name="answer">data answer</param>
        /// <returns></returns>
        Task<int> Answer_AddAsync(TestQuestionAnswerDTO answer);
        /// <summary>
        /// Set IsCorrect or Not Iscorrect for answer
        /// </summary>
        /// <param name="id">id of answer</param>
        /// <returns></returns>
        Task Answer_IsCorrect(int id);
        /// <summary>
        /// get test info for testing
        /// </summary>
        /// <param name="id">user test id</param>
        /// <returns></returns>
        Task<TestItemModel> GetTestItemModelAsync(Guid id);
        /// <summary>
        /// List of results tests
        /// </summary>
        /// <returns></returns>
        Task<List<TestResultDTO>> ResultList();
        /// <summary>
        /// Get results of selected test
        /// </summary>
        /// <param name="id">user test id</param>
        /// <returns></returns>
        Task<UserTestDTO> GetInfoResult(Guid id);
    }
}

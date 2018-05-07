using AutoMapper;
using JSK.BusinessLayer.DTO;
using JSK.BusinessLayer.Interfaces;
using JSK.BusinessLayer.Models;
using JSK.Domain;
using JSK.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JSK.Core.Extensions;
using AutoMapper.QueryableExtensions;

namespace JSK.BusinessLayer.Services
{
    public class TestService : ITestService
    {
        private readonly IUnitOfWork DB;
        private readonly IMapper _mapper;

        public TestService(IUnitOfWork db, IMapper mapper)
        {
            _mapper = mapper;
            DB = db;
        }

        public async Task<List<TestDTO>> Test_ListAsync()
        {
            var data = await DB.TestRepository.GetActiveTestsAsync();
            return _mapper.Map<List<Test>, List<TestDTO>>(data);
        }

        public async Task Test_SaveAsync(TestDTO test)
        {
            Test obj = null;
            if (test.TestId == 0)
            {
                obj = _mapper.Map<TestDTO, Test>(test);
                obj.IsActive = true;
            }
            else
            {
                obj = await DB.TestRepository.QueryList()
                    .Include(n => n.TestQuestions).FirstOrDefaultAsync(n => n.TestId == test.TestId);
                obj.IsRandomQuestionsOrder = test.IsRandomQuestionsOrder;
                obj.Name = test.Name;
            }

            if (test.TestQuestions != null && test.TestId > 0)
            {
                if (obj.TestQuestions == null) obj.TestQuestions = new List<TestQuestion>();
                if (test.TestQuestions.Count == 0)
                    obj.TestQuestions.Clear();
                else
                {
                    test.TestQuestions.ForEach(q =>
                    {
                        TestQuestion qObj = _mapper.Map<TestQuestionDTO, TestQuestion>(q);
                        if (qObj.TestQuestionId == 0)
                            obj.TestQuestions.Add(qObj);
                        else
                        {
                            qObj = obj.TestQuestions.FirstOrDefault(n => n.TestQuestionId == q.TestQuestionId);
                            if (qObj != null)
                            {
                                qObj.Question = q.Question;
                                qObj.IsSingleAnswer = q.IsSingleAnswer;
                                qObj.IsActive = q.IsActive;
                            }
                        }
                    });
                }
            }


            if (obj.TestId == 0)
                DB.TestRepository.Add(obj);

            await DB.SaveChangesAsync();

        }

        public async Task<TestDTO> Test_GetAsync(int id, bool isFull = false, bool isOnlActiveRecords = true)
        {
            Test data = null;

            if (isFull)
            {
                data = await DB.TestRepository.GetFullItem(id);
                if (isOnlActiveRecords)
                {
                    data.TestQuestions.RemoveAll(x => x.IsActive == false);
                    foreach (var t in data.TestQuestions)
                        t.TestQuestionAnswers.RemoveAll(x => x.IsActive == false);
                }
            }
            else
                data = await DB.TestRepository.FindByIdAsync(id);

            return _mapper.Map<Test, TestDTO>(data);
        }

        public async Task<TestDTO> Test_GetAsync(Guid userTestId)
        {
            Test data = await DB.UserTestRepository.GetTest(userTestId);
            return _mapper.Map<Test, TestDTO>(data);
        }



        public async Task Test_RemoveAsync(int id)
        {
            var obj = await DB.TestRepository.FindByIdAsync(id);
            obj.IsActive = false;
            await DB.SaveChangesAsync();
        }

        public async Task Answer_RemoveAsync(int id)
        {
            var obj = await DB.TestQuestionAnswerRepository.FindByIdAsync(id);
            obj.IsActive = false;
            await DB.SaveChangesAsync();
        }

        public async Task<int> Answer_AddAsync(TestQuestionAnswerDTO answer)
        {
            var obj = _mapper.Map<TestQuestionAnswerDTO, TestQuestionAnswer>(answer);
            DB.TestQuestionAnswerRepository.Add(obj);
            await DB.SaveChangesAsync();
            return obj.TestQuestionAnswerId;
        }

        public async Task Answer_IsCorrect(int id)
        {
            var obj = await DB.TestQuestionAnswerRepository.FindByIdAsync(id);
            obj.IsCorrect = !obj.IsCorrect;
            await DB.SaveChangesAsync();
        }



        public async Task<TestItemModel> GetTestItemModelAsync(Guid id)
        {
            TestItemModel model = new TestItemModel();

            var userTest = await DB.UserTestRepository.FindByIdAsync(id);
            //Get test item
            var test = await Test_GetAsync(userTest.TestId, true, true);

            model.ID = id;
            model.TestId = test.TestId;
            model.TestName = test.Name;

            //Get free questions fot this test
            var userQuestion = _mapper.Map<List<TestQuestion>, List<TestQuestionDTO>>(await DB.TestQuestionRepository.GetTestQuestionsByTest(id));
            var freeQuestoins = test.TestQuestions.Where(n => !userQuestion.Select(x => x.TestQuestionId).Contains(n.TestQuestionId)).ToList();
            TestQuestionDTO topQuestion = null;
            if (freeQuestoins.Count > 0)
            {
                if (test.IsRandomQuestionsOrder)
                    topQuestion = freeQuestoins.OrderBy(n => Guid.NewGuid()).FirstOrDefault();
                else
                    topQuestion = freeQuestoins.FirstOrDefault();
            }

            if (topQuestion != null)
            {
                model.QuestionId = topQuestion.TestQuestionId;
                model.QuestionName = topQuestion.Question;
                model.IsSingleAnswer = topQuestion.IsSingleAnswer;

                model.Answers = topQuestion.TestQuestionAnswers;
            }
            else
            {
                //is test completed
                model.IsComplete = true;
            }


            return model;
        }

        public async Task<List<TestResultDTO>> ResultList()
        {
            return await DB.UserTestRepository.SelectResults().ProjectTo<TestResultDTO>().ToListAsync();
        }
    }
}

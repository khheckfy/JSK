using AutoMapper;
using JSK.BusinessLayer.DTO;
using JSK.BusinessLayer.Interfaces;
using JSK.Domain;
using JSK.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var data = await DB.TestRepository.QueryList().Where(n => n.IsActive == true).ToListAsync();
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

            if (test.TestQuestions != null)
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

        public async Task<TestDTO> Test_GetAsync(int id)
        {
            var data = await DB.TestRepository.GetFullItem(id);
            return _mapper.Map<Test, TestDTO>(data);
            //var data = await DB.TestRepository.FindByIdAsync(id);
            //var obj = _mapper.Map<Test, TestDTO>(data);
            //var qList = await DB.TestQuestionRepository
            //    .QueryList()
            //    .Include(n => n.TestQuestionAnswers)
            //    .Where(n => n.TestId == id && n.IsActive == true)
            //    .ToListAsync();
            //obj.Questions = _mapper.Map<List<TestQuestion>, List<TestQuestionDTO>>(qList);
            //return obj;
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
    }
}

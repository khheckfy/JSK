using AutoMapper;
using JSK.BusinessLayer.DTO;
using JSK.BusinessLayer.Interfaces;
using JSK.Domain;
using JSK.Domain.Entities;
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
            var data = await DB.TestRepository.GetAllAsync();
            return _mapper.Map<List<Test>, List<TestDTO>>(data);
        }

        public async Task Test_SaveAsync(TestDTO test)
        {
            Test obj = null;
            if (test.TestId == 0)
                obj = _mapper.Map<TestDTO, Test>(test);
            else
            {
                obj = await DB.TestRepository.FindByIdAsync(test.TestId);
                obj.IsRandomQuestionsOrder = test.IsRandomQuestionsOrder;
                obj.Name = test.Name;
            }

            if (obj.TestQuestions == null)
                obj.TestQuestions = new List<TestQuestion>();

            if (test.Questions != null && test.Questions.Count > 0)
            {
                test.Questions.ForEach(q =>
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
                        }
                    }
                });

            }


            if (obj.TestId == 0)
                DB.TestRepository.Add(obj);

            await DB.SaveChangesAsync();

        }

        public async Task<TestDTO> Test_GetAsync(int id)
        {
            var data = await DB.TestRepository.FindByIdAsync(id);
            var obj = _mapper.Map<Test, TestDTO>(data);
            var qList = DB.TestQuestionRepository.QueryList().Where(n => n.TestId == id).ToList();
            obj.Questions = _mapper.Map<List<TestQuestion>, List<TestQuestionDTO>>(qList);
            return obj;
        }

        public async Task Test_RemoveAsync(int id)
        {
            var obj = await DB.TestRepository.FindByIdAsync(id);
            DB.TestRepository.Remove(obj);
            await DB.SaveChangesAsync();
        }
    }
}

using AutoMapper;
using JSK.BusinessLayer.DTO;
using JSK.BusinessLayer.Interfaces;
using JSK.Domain;
using JSK.Domain.Entities;
using System.Collections.Generic;
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

            if (obj.TestId == 0)
                DB.TestRepository.Add(obj);

            await DB.SaveChangesAsync();

        }

        public async Task<TestDTO> Test_GetAsync(int id)
        {
            return _mapper.Map<Test, TestDTO>(await DB.TestRepository.FindByIdAsync(id));
        }

        public async Task Test_RemoveAsync(int id)
        {
            var obj = await DB.TestRepository.FindByIdAsync(id);
            DB.TestRepository.Remove(obj);
            await DB.SaveChangesAsync();
        }
    }
}

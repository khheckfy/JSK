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

        public async Task<List<TestDTO>> Test_List()
        {
            var data = await DB.TestRepository.GetAllAsync();
            return _mapper.Map<List<Test>, List<TestDTO>>(data);
        }
    }
}

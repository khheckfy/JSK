using AutoMapper;
using JSK.BusinessLayer.DTO;
using JSK.BusinessLayer.Interfaces;
using JSK.BusinessLayer.Models;
using JSK.Domain;
using JSK.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace JSK.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork DB;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork db, IMapper mapper)
        {
            _mapper = mapper;
            DB = db;
        }

        public async Task<Guid> CreateUser(UserDTO user, int testId)
        {
            var obj = await DB.UserRepository.GetByEmail(user.Email);
            //if user exists by email, then change user name, if its not equal
            if (obj == null)
            {
                obj = new Domain.Entities.User()
                {
                    Email = user.Email,
                    Name = user.Name
                };

                DB.UserRepository.Add(obj);
            }
            else if (obj.Name != user.Name)
            {
                obj.Name = user.Name;
                await DB.SaveChangesAsync();
            }


            //Create user test entity, for history
            UserTest userTest = new UserTest()
            {
                UserTestId = Guid.NewGuid(),
                TestId = testId,
                User = obj,
                CreatedOn = DateTime.Now
            };

            DB.UserTestRepository.Add(userTest);
            await DB.SaveChangesAsync();

            return userTest.UserTestId;
        }

        public async Task UseAnswer(UserAnswerModel model)
        {
            var userTest = await DB.UserTestRepository.FindByIdAsync(model.UserTetstId);
            if (model.IsTextAnser)
            {
                DB.UserTestAnswerRepository.Add(new UserTestAnswer()
                {
                    AnswerText = model.AnswerText,
                    UserTestId = model.UserTetstId,
                    UserId = userTest.UserId,
                    TestQuestionId = model.QuestionId
                });
            }
            else
            {
                foreach (var a in model.Answers)
                {
                    DB.UserTestAnswerRepository.Add(new UserTestAnswer()
                    {
                        UserTestId = model.UserTetstId,
                        TestQuestionAnswerId = a,
                        UserId = userTest.UserId,
                        TestQuestionId = model.QuestionId
                    });
                }
            }

            await DB.SaveChangesAsync();
        }
    }
}

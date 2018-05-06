using AutoMapper;
using JSK.BusinessLayer.DTO;
using JSK.BusinessLayer.Interfaces;
using JSK.Domain;
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

        public async Task<int> CreateUser(UserDTO user)
        {
            var obj = await DB.UserRepository.GetByEmail(user.Email);
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

            await DB.SaveChangesAsync();

            return obj.UserId;
        }
    }
}

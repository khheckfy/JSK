using JSK.BusinessLayer.DTO;
using System;
using System.Threading.Tasks;

namespace JSK.BusinessLayer.Interfaces
{
    public interface IUserService
    {
        Task<Guid> CreateUser(UserDTO user, int testId);
    }
}

using JSK.BusinessLayer.DTO;
using JSK.BusinessLayer.Models;
using System;
using System.Threading.Tasks;

namespace JSK.BusinessLayer.Interfaces
{
    public interface IUserService
    {
        Task<Guid> CreateUser(UserDTO user, int testId);
        Task UseAnswer(UserAnswerModel model);
    }
}

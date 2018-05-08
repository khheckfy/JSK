using JSK.BusinessLayer.DTO;
using JSK.BusinessLayer.Models;
using System;
using System.Threading.Tasks;

namespace JSK.BusinessLayer.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Cerate user or find user by email, and Create userTest object
        /// </summary>
        /// <param name="user">User info</param>
        /// <param name="testId">selected test id</param>
        /// <returns></returns>
        Task<Guid> CreateUser(UserDTO user, int testId);
        /// <summary>
        /// Answer action of user
        /// </summary>
        /// <param name="model">answer info</param>
        /// <returns></returns>
        Task UseAnswer(UserAnswerModel model);
    }
}

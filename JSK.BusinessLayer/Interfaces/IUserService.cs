using JSK.BusinessLayer.DTO;
using System.Threading.Tasks;

namespace JSK.BusinessLayer.Interfaces
{
    public interface IUserService
    {
        Task<int> CreateUser(UserDTO user);
    }
}

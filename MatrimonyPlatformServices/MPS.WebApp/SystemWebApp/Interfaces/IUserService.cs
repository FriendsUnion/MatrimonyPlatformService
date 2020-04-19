using MPS.Shared.Models;
using System.Threading.Tasks;

namespace SystemMatrimonyWebApp.Interfaces
{
    public interface IUserService
    {
        Task<UserDetail> ValidateUserCredential(UserCredential userCredential, string SecretKey);
    }
}

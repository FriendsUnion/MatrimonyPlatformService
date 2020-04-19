
using MPS.Shared;
using MPS.Shared.Models;
using System.Threading.Tasks;

namespace Authentication.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Validates user credentials
        /// </summary>
        /// <param name="credential">The user login credentials</param>
        /// <returns>UserDetail</returns>
        Task<UserDetail> ValidateUserCredential(UserCredential credential);
        
    }
}

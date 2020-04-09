using Authentication.Interfaces;
using Authentication.Models;
using Microsoft.Extensions.Logging;
using MPS.Shared;
using System.Threading.Tasks;

namespace Authentication.Services
{
    public class UserService : IUserService
    {
        private IAuthenticationTokenProvider _tokenProvider;
        private ILogger _logger;
        public UserService(ILogger<UserService> logger, IAuthenticationTokenProvider tokenProvider)
        {
            _logger = logger;
            _tokenProvider = tokenProvider;
        }

        public Task<UserDetail> ValidateUserCredential(UserCredential credential)
        {
            //Validate credentials against database
            UserDetail userDetail = new UserDetail();
            var token = _tokenProvider.GenerateAuthenticationToken(userDetail, credential.RequestIssuer);
            userDetail.SetAuthenticationToken(token);
            return Task.FromResult(userDetail);
        }        
    }
}

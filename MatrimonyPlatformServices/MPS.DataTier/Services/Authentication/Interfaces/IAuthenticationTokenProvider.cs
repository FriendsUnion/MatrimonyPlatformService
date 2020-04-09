using MPS.Shared;

namespace Authentication.Interfaces
{
    public interface IAuthenticationTokenProvider
    {
        /// <summary>
        /// Generates a new JWT authentication token for validating subsequent request
        /// </summary>
        /// <param name="userDetail">The user details used to validate user</param>
        /// <param name="requestIssuer">The request issuer</param>
        /// <returns>String authentication token</returns>
        string GenerateAuthenticationToken(UserDetail userDetail, string requestIssuer);
    }
}

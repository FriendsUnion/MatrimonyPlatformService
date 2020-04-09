using System;

namespace MPS.Shared
{
    public class UserDetail
    {
        public Int32 UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AuthToken { get; private set; }
        public void SetAuthenticationToken(string authToken)
        {
            AuthToken = AuthToken;
        }

        /// <summary>
        /// Generates a unique string used in authentication mechanism
        /// </summary>
        /// <returns>Unique string</returns>
        public override string ToString()
        {
            return $"{UserId}#{UserName}${Password}";
        }
    }
}

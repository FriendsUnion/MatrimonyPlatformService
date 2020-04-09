namespace Authentication.Models
{
    /// <summary>
    /// Defines data members required to validate user
    /// </summary>
    public class UserCredential
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string RequestIssuer { get; private set; }
        public UserCredential(string userName, string password, string requestIssuer)
        {
            UserName = userName;
            Password = password;
            RequestIssuer = requestIssuer;
        }
    }
}

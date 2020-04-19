using Microsoft.Extensions.Configuration;
using System;

namespace SystemMatrimonyWebApp.Models
{
    public class userCredetinalModel
    {
        private readonly IConfiguration _configuration;
        public userCredetinalModel(IConfiguration configuration)
        {
            _configuration = configuration;
            MaxRetryLoginAttempt = Convert.ToInt32(_configuration["MaxRetryLoginAttempt"]);
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string RequestIssuer { get; set; }
        public bool LoginAttemptsRemaning { get; set; }
        private int MaxRetryLoginAttempt { get; set; }
        public int CurrentRetryLoginAttempt { get; set; }
        public bool validateCaptcha => CurrentRetryLoginAttempt > 0;
        public bool HasMaxLoginAttemptReached => MaxRetryLoginAttempt - CurrentRetryLoginAttempt == 0;
    }
}

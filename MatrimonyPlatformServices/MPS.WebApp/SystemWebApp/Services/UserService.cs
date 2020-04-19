using MPS.Shared.Models;
using System;
using System.Threading.Tasks;
using SystemMatrimonyWebApp.Interfaces;
using MPS.Shared.Cryptography;
using Microsoft.Extensions.Configuration;

namespace SystemMatrimonyWebApp.Services
{
    public class UserService : IUserService
    {
        public Task<UserDetail> ValidateUserCredential(UserCredential userCredential, string SecretKey)
        {
            //var credential = Cryptography.Encrypt<UserCredential>(userCredential, SecretKey);
            ////Call API to access the data
            //return credential;
            throw new NotImplementedException();
        }
    }
}

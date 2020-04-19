using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MPS.Shared.Models;
using SystemMatrimonyWebApp.Interfaces;
using SystemMatrimonyWebApp.Models;
using SystemWebApp.Models;

namespace SystemWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUserService _userService;
        private IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            userService = _userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginValidate(userCredetinalModel userCredential)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isCaptchaEnabled = Convert.ToBoolean(_configuration["EnableCaptcha"]);
                    UserCredential credential = new UserCredential(userCredential.UserName, userCredential.Password, "website");

                    if (userCredential.validateCaptcha && isCaptchaEnabled)
                    {
                        //Validate Captcha;
                    }
                    //var userDetail = _userService.ValidateUserCredential(credential);
                    //if (userDetail == null)
                    //{
                    //    userCredential.CurrentRetryLoginAttempt++;
                    //    if (userCredential.HasMaxLoginAttemptReached)
                    //    {
                    //        //send to custom error page and block the user until admin Unlocks ;
                    //    }
                    //    if (isCaptchaEnabled)
                    //    {
                    //        //Show captcha code in UI;
                    //    }
                    //}
                    //else
                    //{
                    //    //Redirect to Dashboard view;
                    //}
                }
                else
                {
                    //Show error message;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

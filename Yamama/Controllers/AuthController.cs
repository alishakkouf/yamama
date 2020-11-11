using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Yamama.Repository;
using Yamama.Services;
using Yamama.ViewModels;

namespace Yamama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {


        private readonly UserManager<ExtendedUser> userManager;
        private readonly SignInManager<ExtendedUser> signInManager;
        private readonly ILogger<AuthController> logger;
        private readonly ISmsSender smsSender;
        private readonly IEmailSender _emailSender ;

        public AuthController(UserManager<ExtendedUser> userManager,
                                     SignInManager<ExtendedUser> signInManager,
                                     ILogger<AuthController> logger, ISmsSender smsSender , IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.smsSender = smsSender;
            _emailSender = emailSender;

        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserRegisterInformation userRegisterInformation)
        {
            //try
            //{
                //check if the email is in use
                var user1 = await userManager.FindByEmailAsync(userRegisterInformation.E_mail);
                if (user1 == null)
                {

                    var user = new ExtendedUser
                    {
                        UserName = userRegisterInformation.UserName,
                        Email = userRegisterInformation.E_mail,
                        FullName = userRegisterInformation.FullName,
                        PhoneNumber = userRegisterInformation.PhoneNumber
                    };
                    var result = await userManager.CreateAsync(user, userRegisterInformation.Password);

                    if (result.Succeeded)
                    {


                        //var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                        //var confirmationlink = Url.Action("ConfirmEmail", "Auth", new { userId = user.Id, Token = token }, Request.Scheme);

                        //logger.Log(LogLevel.Warning, confirmationlink);
                        await userManager.AddToRoleAsync(user, userRegisterInformation.Role);
                        return Ok("successful");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else { return BadRequest("the email is in use !! try another email"); }

            //}
            //catch (Exception)
            //{
            //    return BadRequest();
            //}
        }



        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginInformation loginInformation)
        {

            try
            {
                var result = await signInManager.PasswordSignInAsync(loginInformation.E_mail,
                                                                     loginInformation.Password,
                                                                     loginInformation.RememberMe, false);

                if (result.Succeeded)
                {
                    return Ok();
                }
                else if (result.IsNotAllowed)
                {
                    return BadRequest("Email need to be confirmed !!");
                }

                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest("please check your Email or Password !!");
            }
        }


        [HttpPost]
        [Route("Logout")]
        public async Task<ActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return Ok();
        }


        //[HttpPost]
        //[Route("Login2factor")]
        //public async Task<IActionResult> Login2factor(TwoFactor twoFactor)
        //{
        //    string message = "Your code is " + "1996";

        //    var test = await smsSender.SendSmsAsync(twoFactor.number, message);
        //    return Ok();
        
        //}

        [HttpGet]
        [Route("ListUsers")]
        public async Task<IActionResult> ListUsers()
        {
            var users = userManager.Users;
            return Ok(users);
        }

        [HttpPost]
        [Route("EditUser")]
        public async Task<IActionResult> EditUser(string id, UserRegisterInformation userRegisterInformation)
        {
            //fetch the user
            var user = await userManager.FindByIdAsync(id);

            //update user information
            user.Email = userRegisterInformation.E_mail;
            user.FullName = userRegisterInformation.FullName;
            user.PhoneNumber = userRegisterInformation.PhoneNumber;
            user.UserName = userRegisterInformation.UserName;

            //check if the role changed or not
            var testAssign = await userManager.IsInRoleAsync(user, userRegisterInformation.Role);
            if (!testAssign)
            {
                //add new role to the user
                await userManager.AddToRoleAsync(user, userRegisterInformation.Role);
            }

            //update user in database
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }


        }

        [HttpPost]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            //fetch the user
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                //delete user
                var result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("The user not found");
                }
            }
            return BadRequest("The user not found");

        }


        [HttpGet]
        [Route("GetUser")]
        public async Task<ExtendedUser> GetUser(string id)
        {
            //fetch the user
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            { return user; }
            else
            {
                // return BadRequest("The user not found");
                return null;
            }
        }


        [HttpGet]
        [Route("GetCurrentUserId")]
        public async Task<string> GetCurrentUserId()
        {
            var usr = await GetCurrentUserAsync();
            return usr?.Id;
        }

        private Task<ExtendedUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);

        //decrypt PasswordHash to readable password
        public static string base64Decode(string sData) //Decode    
        {
            try
            {
                var encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecodeByte = Convert.FromBase64String(sData);
                int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
                char[] decodedChar = new char[charCount];
                utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
                string result = new String(decodedChar);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Decode" + ex.Message);
            }
        }



        //Email module is 80% ready , it needs some configurations
        [HttpPost]
        [Route("sendEmail")]
        public async Task<IActionResult> sendEmail(string pass , string to_email, string subject, string message, string attachement)
        {
            try
            {
                //current user_id
                string id = await GetCurrentUserId();
                var sender = await GetUser(id);
                string from_email = sender.Email;
                string password = pass;
                int result = await _emailSender.SendEmailAsync(from_email, password, to_email, subject, message, attachement);

                if (result == 1)
                {
                    var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", result);
                    return Ok(Response);
                }
                else
                {
                    var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", result);
                    return Ok(Response);
                }
                

            }
            catch { return BadRequest(); }
        }
    }
}


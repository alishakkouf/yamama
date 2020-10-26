using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public AuthController(UserManager<ExtendedUser> userManager,
                                     SignInManager<ExtendedUser> signInManager,
                                     ILogger<AuthController> logger,ISmsSender smsSender)
            {
                this.userManager = userManager;
                this.signInManager = signInManager;
            this.logger = logger;
            this.smsSender = smsSender;

        }

            [HttpPost]
            [Route("Register")]
            public async Task<IActionResult> Register(UserRegisterInformation userRegisterInformation)
            {
                try
                {
                    //check if the email is in use
                    var user1 = await userManager.FindByEmailAsync(userRegisterInformation.E_mail);
                    if (user1 == null)
                    {

                        var user = new ExtendedUser { UserName = userRegisterInformation.UserName,
                                                      Email = userRegisterInformation.E_mail,
                            FullName = userRegisterInformation.FullName,
                            PhoneNumber = userRegisterInformation.PhoneNumber};
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

                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }



            [HttpPost]
            [Route("Login")]
            public async Task<IActionResult> Login(LoginInformation loginInformation)
            {

                try
                { var result = await signInManager.PasswordSignInAsync(loginInformation.E_mail,
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


        [HttpPost]
        [Route("Login2factor")]
        public async Task<IActionResult> Login2factor(TwoFactor twoFactor)
        {
            string message = "Your code is " + "1996";
           
            var test = await smsSender.SendSmsAsync(twoFactor.number, message);
                return Ok();

         
          
          
           
        }

        [HttpGet]
        [Route("ListUsers")]
        public async Task<IActionResult> ListUsers()
        {
            var users = userManager.Users;
            return Ok(users);
        }

        [HttpPost]
        [Route("EditUser")]
        public async Task<IActionResult> EditUser(string id , UserRegisterInformation userRegisterInformation)
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
        public async Task<IActionResult> DeleteUser (string id)
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
        public async Task<IActionResult> GetUser(string id)
        {
            //fetch the user
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            { return Ok(user); }
                else
                {
                    return BadRequest("The user not found");
                }
        }
            


    }
}

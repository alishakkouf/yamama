using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Yamama.ViewModels;

namespace Yamama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
      
      
            private readonly UserManager<IdentityUser> userManager;
            private readonly SignInManager<IdentityUser> signInManager;

            public AuthController(UserManager<IdentityUser> userManager,
                                     SignInManager<IdentityUser> signInManager)
            {
                this.userManager = userManager;
                this.signInManager = signInManager;
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

                        var user = new IdentityUser { UserName = userRegisterInformation.UserName, Email = userRegisterInformation.E_mail };
                        var result = await userManager.CreateAsync(user, userRegisterInformation.Password);

                        if (result.Succeeded)
                        {
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
                {

                    var result = await signInManager.PasswordSignInAsync(loginInformation.E_mail, loginInformation.Password,
                                                      loginInformation.RememberMe, false);

                    if (result.Succeeded)
                    {

                        return Ok();
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
        }
    }

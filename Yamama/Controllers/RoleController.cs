using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Yamama.ViewModels;

namespace Yamama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // POST api/<RoleController>
        [HttpPost]
        [AllowAnonymous]
        //[Authorize]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
        {
            try
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = createRoleViewModel.RoleName
                };
                IdentityResult result = await _roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return Ok();
                }
                else return BadRequest();

            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        // POST api/<RoleController>
        [HttpPost]
        //[Authorize]
        [Route("EditRole")]
        public async Task<IActionResult> EditRole(CreateRoleViewModel createRoleViewModel)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(createRoleViewModel.id);


                if (role != null)
                {
                    role.Name = createRoleViewModel.RoleName;
                    var result = await _roleManager.UpdateAsync(role);

                    if (result.Succeeded)
                    {
                        return Ok();
                    }
                    else

                    { return BadRequest(); }

                }
                else return BadRequest();

            }
            catch (Exception)
            {

                return BadRequest();
            }

        }


        // POST api/<RoleController>
        [HttpPost]
        //[Authorize]
        [Route("DeleteRole")]
        public async Task<IActionResult> DeleteRole(string Id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(Id);


                if (role != null)
                {

                    var result = await _roleManager.DeleteAsync(role);

                    if (result.Succeeded)
                    {
                        return Ok();
                    }
                    else

                    { return BadRequest(); }

                }
                else return BadRequest();

            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        // Get api/<RoleController>
        [HttpGet]
        //[Authorize]
        [Route("GetRoles")]
        public IActionResult GetRoles()
        {
            var roles = _roleManager.Roles;
            return Ok(roles);
        }
    }
}
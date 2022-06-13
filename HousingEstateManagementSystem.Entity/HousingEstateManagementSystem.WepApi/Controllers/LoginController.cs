using HousingEstateManagementSystem.Entity.Base;
using HousingEstateManagementSystem.Entity.Dto;
using HousingEstateManagementSystem.Entity.IBase;
using HousingEstateManagementSystem.Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingEstateManagementSystem.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        
        public LoginController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IResponse<DtoLogin>> Register(DtoLogin login)
        {

            try
            {
                
                var result = await _signInManager.PasswordSignInAsync(login.email, login.password, false, true);


                return new Response<DtoLogin>
                {
                    Message = "Giriş yapıldı.",
                    StatusCode = StatusCodes.Status200OK,
                    Data = login
                };
            }
            catch (Exception ex)
            {
                return new Response<DtoLogin>
                {
                    Message = "Error:" + ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }
    }
}

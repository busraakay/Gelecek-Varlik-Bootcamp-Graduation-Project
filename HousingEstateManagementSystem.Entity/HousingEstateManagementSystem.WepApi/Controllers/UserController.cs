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
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<IResponse<User>> Create(DtoRegister register)
        {
            try
            {
                User user = new User()
                {
                    UserEmail = register.UserEmail,
                    UserNameSurname = register.UserNameSurname,
                    UserTrIdentityNo = register.UserTrIdentityNo,
                    UserVehicleInfo = register.UserVehicleInfo,
                    UserStatus = register.UserStatus,
                    Email = register.UserEmail,
                    UserName = register.UserEmail
                };

                var result = await _userManager.CreateAsync(user, register.Password);

                return new Response<User>
                {
                    Message = "Kullanıcı üretildi.",
                    StatusCode = StatusCodes.Status200OK,
                    Data = user
                };
            }
            catch (Exception ex)
            {
                return new Response<User>
                {
                    Message = "Error:" + ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }

        [HttpPut("Update")]
        public async Task<IResponse<User>> Update(DtoRegister _user)
        {
            try
            {
                User user = await _userManager.FindByNameAsync(_user.UserEmail);
                user.UserEmail = _user.UserEmail;
                user.UserNameSurname = _user.UserNameSurname;
                user.UserTrIdentityNo = _user.UserTrIdentityNo;
                user.UserVehicleInfo = _user.UserVehicleInfo;
                user.UserStatus = _user.UserStatus;
                user.Email = _user.UserEmail;
                user.UserName = _user.UserEmail;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, _user.Password);
                var result = await _userManager.UpdateAsync(user);

                return new Response<User>
                {
                    Message = "Kullanıcı güncellendi.",
                    StatusCode = StatusCodes.Status200OK,
                    Data = user
                };
            }
            catch (Exception ex)
            {
                return new Response<User>
                {
                    Message = "Error:" + ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }

        [HttpDelete("Delete")]
        public async Task<IResponse<User>> Delete(string mail)
        {
            try
            {
                User user = await _userManager.FindByNameAsync(mail);

                IdentityResult result = await _userManager.DeleteAsync(user);

                return new Response<User>
                {
                    Message = "Kullanıcı silindi.",
                    StatusCode = StatusCodes.Status200OK,
                    Data = user
                };
            }
            catch (Exception ex)
            {
                return new Response<User>
                {
                    Message = "Error:" + ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }
    }
}

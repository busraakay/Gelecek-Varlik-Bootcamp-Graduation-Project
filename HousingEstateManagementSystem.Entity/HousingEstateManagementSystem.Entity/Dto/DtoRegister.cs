using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateManagementSystem.Entity.Dto
{
    public class DtoRegister
    {
        public string UserNameSurname { get; set; }
        public string UserTrIdentityNo { get; set; }
        public string UserEmail { get; set; }
        public string? UserVehicleInfo { get; set; }
        public string UserStatus { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen şifre giriniz.")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor!")]
        public string ConfirmPassword { get; set; }


    }
}

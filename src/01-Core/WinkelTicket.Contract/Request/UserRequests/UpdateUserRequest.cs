using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WinkelTicket.Contract.Request.UserRequests
{
    public class UpdateUserRequest
    {
        public string Id { get; set; }
        
        [Required(ErrorMessage = "Kullanıcı Adı boş bırakılamaz")]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Kullanıcı Soyadı boş bırakılamaz")]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email boş bırakılamaz")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Geçerli bir mail adresi giriniz.")]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage = "Şifreniz en az 6 karakterli olmalıdır.")]
        public string Password { get; set; }

        [Display(Name = "Onay Şifreniz")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Yeni şifreniz ve onay şifreniz aynı olmalıdır")]
        public string PasswordConfirm { get; set; }
    }
}
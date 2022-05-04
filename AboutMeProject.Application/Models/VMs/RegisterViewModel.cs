using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Models.VMs
{
   public class RegisterViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please UserName Not Null...")]
        [StringLength(15, ErrorMessage = "Lütfen kullanıcı adını 4 ile 15 karakter arasında giriniz...", MinimumLength = 4)]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen emaili boş geçmeyiniz...")]
        [EmailAddress(ErrorMessage = "Lütfen email formatında bir değer belirtiniz...")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi boş geçmeyiniz...")]
        [DataType(DataType.Password, ErrorMessage = "Lütfen şifreyi tüm kuralları göz önüne alarak giriniz...")]
        [Display(Name = "Sifre")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi Tekrar Girin...")]
     [Compare("Password",ErrorMessage ="Şifreler uyumlu değil")]
        [Display(Name = "Sifre")]
        public string ComfirmPassword { get; set; }

    }
}

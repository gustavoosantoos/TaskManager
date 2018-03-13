using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.WebApplication.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(15, ErrorMessage ="O {0} deve ter no máximo {1} e no mínimo {2} caracteres.", MinimumLength = 4)]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter ao menos {2} e ao máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmação de senha")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação de senha não conferem.")]
        public string ConfirmPassword { get; set; }
    }
}

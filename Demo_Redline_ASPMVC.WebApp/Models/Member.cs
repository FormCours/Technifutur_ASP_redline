using Demo_Redline_ASPMVC.WebApp.CustomDataAnnotation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo_Redline_ASPMVC.WebApp.Models
{
    public class MemberRegister
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"[A-Za-z0-9\-_]+")]
        [Display(Name = "Votre pseudo")]
        public string Pseudo { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [NoTrashEmail(ErrorMessage = "Merci de ne pas utiliser d'adresse mail poubelle ♥")]
        [Display(Name = "Votre adresse electronique")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\.#\-_*+/\\@€£$&^=])(?!(^\s))(?!.*(\s$)).{8,50}$")]
        [DataType(DataType.Password)]
        [Display(Name = "Votre mot de passe")]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmation du mot de passe")]
        public string PasswordConfirme { get; set; }
    }
}
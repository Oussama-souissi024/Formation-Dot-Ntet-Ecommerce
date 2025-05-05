using System.ComponentModel.DataAnnotations;

namespace Formationn_Ecommerce.Application.Authentication.Dtos
{
    public class ResetPasswordDto
    {
        [Required]
        public string UserId { get; set; }
        
        [Required]
        public string Token { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "Le {0} doit contenir au moins {2} caractères et au maximum {1} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nouveau mot de passe")]
        public string NewPassword { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe")]
        [Compare("NewPassword", ErrorMessage = "Le nouveau mot de passe et la confirmation du mot de passe ne correspondent pas.")]
        public string ConfirmPassword { get; set; }
    }
}

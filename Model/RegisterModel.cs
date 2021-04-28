/*using System.ComponentModel.DataAnnotations;

namespace BookManagement.Model
{
    public class RegisterModel
    {
        
        [Required]
        public string UserName {get; set;}

        [Required]
        [Display(Name = "Email Adress")]
        public string Email {get; set;}

        [Required]
        [Display(Name = "Password")]
        public string Password{get; set;}

        [Required]
        [Display(Name = "Confirm Name")]
        [Compare("Password",ErrorMessage = "Confirm Password and Password do not match")]
        public string ConfirmPassword{get; set;}
        
    }
}*/
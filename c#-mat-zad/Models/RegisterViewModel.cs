using System.ComponentModel.DataAnnotations;

namespace NotesAppAspNet.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hesla se neshodují.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Musíš souhlasit s podmínkami.")]
        public bool Consent { get; set; }
    }
}

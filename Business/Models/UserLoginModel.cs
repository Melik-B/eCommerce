using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Business.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "{0} is required!")]
        [MinLength(3, ErrorMessage = "{0} must be at least {1} characters!")]
        [MaxLength(30, ErrorMessage = "{0} must be at most {1} characters!")]
        [DisplayName("Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(10, ErrorMessage = "{0} must be at most {1} characters!")]
        [DisplayName("Password")]
        public string Password { get; set; }

    }
}

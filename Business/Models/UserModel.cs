using AppCore.Records.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using DataAccess.Enums;
using System.Xml.Linq;

namespace Business.Models
{
    public class UserModel: RecordBase
    {
        [Required(ErrorMessage = "{0} is required!")]
        [MinLength(3, ErrorMessage = "{0} must be at least {1} characters!")]
        [MaxLength(30, ErrorMessage = "{0} must be at most {1} characters!")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [MinLength(3, ErrorMessage = "{0} must be at least {1} characters!")]
        [MaxLength(30, ErrorMessage = "{0} must be at most {1} characters!")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [MinLength(3, ErrorMessage = "{0} must be at least {1} characters!")]
        [MaxLength(50, ErrorMessage = "{0} must be at most {1} characters!")]
        [DisplayName("Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(10, ErrorMessage = "{0} must be at most {1} characters!")]
        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        [DisplayName("Role")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(200, ErrorMessage = "{0} must be at least {1} characters!")]
        [DisplayName("E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        public string Address { get; set; }

        public Gender Gender { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("Country")]
        public int? CountryId { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("City")]
        public int? CityId { get; set; }

        public string RoleNameDisplay { get; set; }

    }
}

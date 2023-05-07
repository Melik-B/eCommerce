using AppCore.Records.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Business.Models
{
    public class CityModel: RecordBase
    {
        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(170, ErrorMessage = "{0} must be at most {1} characters!")]
        [DisplayName("City Name")]
        public string Name { get; set; }

        public int CountryId { get; set; }

        public string CountryNameDisplay { get; set; }
    }
}

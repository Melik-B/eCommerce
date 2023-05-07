using AppCore.Records.Bases;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace DataAccess.Entities
{
    public class City : RecordBase
    {
        [Required]
        [StringLength(170)]
        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public List<UserDetail> UserDetails { get; set; }
    }
}

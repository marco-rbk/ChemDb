using System.ComponentModel.DataAnnotations;

namespace VibeMapper.Core.Models
{
    public class DNEL
    {
        [Key]
        public int Id { get; set; }
        public string ExposureRoute { get; set; } = "";
        public string ExposedGroup { get; set; } = "";
        public string ExposureType { get; set; } = "";
        public decimal? Value { get; set; }
        public string Unit { get; set; } = "";
    }
}

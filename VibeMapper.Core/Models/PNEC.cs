using System.ComponentModel.DataAnnotations;

namespace VibeMapper.Core.Models
{
    public class PNEC
    {
        [Key]
        public int Id { get; set; }
        public string Compartment { get; set; } = "";
        public decimal? Value { get; set; }
        public string Unit { get; set; } = "";
    }
}

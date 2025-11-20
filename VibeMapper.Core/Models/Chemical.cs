using System.ComponentModel.DataAnnotations;

namespace VibeMapper.Core.Models
{
    public class Chemical
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "CAS Number is required")]
        public string? CASNumber { get; set; }
        [Required(ErrorMessage = "EC Number is required")]
        public string? ECNumber { get; set; }
        public List<DNEL> DNELs { get; set; } = new();
        public List<PNEC> PNECs { get; set; } = new();
    }
}

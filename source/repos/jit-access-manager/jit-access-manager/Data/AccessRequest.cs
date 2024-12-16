using System.ComponentModel.DataAnnotations;

namespace jit_access_manager.Models
{
    public class AccessRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Resource { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime RequestTime { get; set; } = DateTime.UtcNow;

        public DateTime? ExpirationTime { get; set; }
    }
}

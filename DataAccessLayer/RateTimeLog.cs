using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollama_API_Teting.DataAccessLayer
{
    using System.ComponentModel.DataAnnotations;

    public class RateLimitLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        [StringLength(200)]
        public string Endpoint { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
    }

}

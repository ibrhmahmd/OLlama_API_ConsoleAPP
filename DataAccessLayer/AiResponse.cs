using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollama_API_Teting.DataAccessLayer
{
    using System.ComponentModel.DataAnnotations;

    public class AIResponse
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ResponseText { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        [StringLength(50)]
        public string ModelName { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int SessionId { get; set; }

        [Range(0, long.MaxValue)]
        public long Tokens { get; set; }

        public List<string> Alternatives { get; set; }

        [Range(0.0, double.MaxValue)]
        public double TokenRate { get; set; }

        public bool IsFinal { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
        public virtual ChatSession ChatSession { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }

}

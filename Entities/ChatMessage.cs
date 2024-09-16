using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ollama_API_Testing.DataAccessLayer
{
    public class ChatMessage
    {
        [Key]
        public Guid ChatMessageID { get; set; }

        [Required]
        public Guid UserID { get; set; }
        public  User User{ get; set; }

        [Required]
        [StringLength(1000)]
        public string Message { get; set; } //Content

        [Required]
        public Guid AIModelID { get; set; }
        public AIModel AIModel { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        public string? VectorRepresentation { get; set; }
                
        [Range(0.0, 1.0)]
        public float? RelevanceScore { get; set; }

        // Foreign keys
        [Required]
        public Guid ChatSessionID { get; set; }
        public virtual ChatSession ChatSession { get; set; }

        // Navigation property
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}

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
        [StringLength(50)]
        public Guid UserID { get; set; }

        [Required]
        public string Message { get; set; } //Content

        [Required]
        public DateTime Timestamp { get; set; }

        public string? VectorRepresentation { get; set; }

        [Range(0.0, 1.0)]
        public float? RelevanceScore { get; set; }

        // Foreign keys
        [Required]
        public Guid ChatSessionID { get; set; }
        public virtual ChatSession ChatSession { get; set; }

        public Guid? AIResponseID { get; set; }
        public virtual AIResponse AIResponse { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ollama_API_Testing.DataAccessLayer
{
    public class AIResponse
    {
        [Key]
        public Guid AIResponseID { get; set; }

        [Required]
        public string ResponseText { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        [StringLength(50)]
        public string ModelName { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public Guid ChatSessionID { get; set; }
        public virtual ChatSession ChatSession { get; set; }

        public long Tokens { get; set; }

        [Range(0.0, double.MaxValue)]
        public double TokenRate { get; set; }

        // Navigation property
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}

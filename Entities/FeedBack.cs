using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollama_API_Testing.DataAccessLayer
{
    using global::DataAccessLayer.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Feedback
    {
        [Key]
        public Guid FeedbackID { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public string? Comment { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public  Guid ChatMessageID { get; set; }
        public ChatMessage ChatMessage { get; set; }

    }
}

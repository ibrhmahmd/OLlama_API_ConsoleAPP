using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ollama_API_Teting.DataAccessLayer
{
   
    public class ChatSession
    {
        [Key]
        public int SessionId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        [Range(1, int.MaxValue)]
        public int MaxTokens { get; set; }

        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public int ModelId { get; set; }
        [ForeignKey("ModelId")]
        public virtual LanguageModel ModelUsed { get; set; }

        [Required]
        public ChatStatus Status { get; set; }

        [Required]
        public DateTime LastActivityTimestamp { get; set; }

        [Range(0, int.MaxValue)]
        public int TokenUsage { get; set; }

        // Navigation properties
        public virtual ICollection<ChatMessage> Messages { get; set; }
        public virtual ICollection<Prompt> Prompts { get; set; }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ollama_API_Testing.DataAccessLayer
{
   
    public class ChatSession
    {
        [Key]
        public Guid ChatSessionID { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        [Range(1, int.MaxValue)]
        public int MaxTokens { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public int ModelId { get; set; }
        public virtual AIModel ModelUsed { get; set; }

        [Range(0, 30000)]
        public int contextStringLength { get; set; }

        // Navigation properties
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }
    }


}

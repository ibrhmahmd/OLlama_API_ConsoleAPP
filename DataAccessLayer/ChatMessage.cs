using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollama_API_Teting.DataAccessLayer
{
    using System.ComponentModel.DataAnnotations;

    public class ChatMessage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Sender { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        public string VectorRepresentation { get; set; }

        [Range(0.0, 1.0)]
        public float RelevanceScore { get; set; }

        // Foreign keys
        public int SessionId { get; set; }
        public virtual ChatSession ChatSession { get; set; }
    }


}

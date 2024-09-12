using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollama_API_Teting.DataAccessLayer
{
    using System.ComponentModel.DataAnnotations;

    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AIResponseId { get; set; }
        public virtual AIResponse AIResponse { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public string Comment { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollama_API_Testing.DataAccessLayer
{
    using global::DataAccessLayer.Entities;
    using System.ComponentModel.DataAnnotations;

    public class AnalyticsLog
    {
        [Key]
        public Guid AnalyticsLogID { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        [StringLength(100)]
        public string EventType { get; set; }

        public string EventDetails { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        public bool IsDeleted { get; set; } // Soft delete flag

    }

}

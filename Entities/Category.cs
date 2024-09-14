using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollama_API_Testing.DataAccessLayer
{
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Key]
        public Guid CategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string? Description { get; set; }

        // Navigation properties
        public virtual ICollection<AIModel> Models { get; set; }
    }

}

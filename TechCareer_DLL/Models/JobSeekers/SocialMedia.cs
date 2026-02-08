using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Models.JobSeekers
{
    public class SocialMedia: BaseClass
    {
        //[Key]
        //public int Id { get; set; } // Primary Key

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } // e.g., "LinkedIn", "GitHub"

        [MaxLength(200)]
        public string? Icon { get; set; } // optional: store icon URL or icon class (e.g., "fa fa-linkedin")

        // 🔹 Navigation property (Many-to-Many relationship)
        public virtual ICollection<JobSeekersSocialMedia>? JobSeekersSocialMedias { get; set; }
    }
}

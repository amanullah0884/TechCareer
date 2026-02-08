using TechCareer_DLL.Models.SiteSettings.Location;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Models.JobSeekers
{
    public class JobSeekerTraining: BaseClass
    {
        //[Key]
        //public int Id { get; set; } // Primary Key

        [Required]
        [ForeignKey("JobSeeker")]
        public int JobSeekerId { get; set; } // FK -> JobSeeker

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } // e.g., "Web Development", "Project Management"

        [Required]
        [MaxLength(200)]
        public string TrainingInstitution { get; set; } // e.g., "BASIS Institute of Technology"

        [Required]
        public TimeSpan Duration { get; set; } // e.g., 00:06:00 for 6 months or use alternative

        [Required]
        public DateTime ExpirationDate { get; set; } // Certificate expiry date (optional in some cases)

        [Required]
        [ForeignKey("Location")]
        public int LocationId { get; set; } // FK -> Location

        // 🔹 Navigation properties
        public virtual JobSeeker? JobSeeker { get; set; }
        public virtual Location? Location { get; set; }
    }
}

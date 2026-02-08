using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Models.JobSeekers
{
    public class JobSeekerAchievement: BaseClass
    {
        //[Key]
        //public int Id { get; set; } // Primary Key

        [Required]
        [ForeignKey("JobSeeker")]
        public int JobSeekerId { get; set; } // FK -> JobSeeker

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } // Achievement title e.g., "Best Employee Award"

        [MaxLength(1000)]
        public string? Description { get; set; } // Optional detailed description

        [MaxLength(200)]
        public string? Issuer { get; set; } // Organization or person issuing the achievement

        [Required]
        public DateTime AchievedDate { get; set; } // Date of achievement

        // 🔹 Navigation property
        public virtual JobSeeker? JobSeeker { get; set; }
    }
}

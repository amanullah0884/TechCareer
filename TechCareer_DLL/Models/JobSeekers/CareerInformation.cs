using TechCareer_DLL.Models.Enums;
using TechCareer_DLL.Models.Recruiters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Models.JobSeekers
{
    public class CareerInformation: BaseClass
    {
        //[Key]
        //public int Id { get; set; } // Primary Key

        [Required]
        [ForeignKey("JobSeeker")]
        public int JobSeekerId { get; set; } // FK -> JobSeeker

        [MaxLength(2000)]
        public string? CareerObjective { get; set; } // Optional: Career objective text

        [Range(0, int.MaxValue)]
        public int? PresentSalary { get; set; } // Optional: Current salary

        [Range(0, int.MaxValue)]
        public int? ExpectedSalary { get; set; } // Optional: Expected salary

        [MaxLength(100)]
        public string? JobLevelLookingFor { get; set; } // Optional: e.g., "Entry Level", "Mid Level", "Senior Level"

        [Required]
        [ForeignKey("JobNature")]
        public int JobNatureId { get; set; } // FK -> JobNature (Full-time, Part-time, Freelance, etc.)

        // 🔹 Navigation properties
        public virtual JobSeeker? JobSeeker { get; set; }
        public virtual JobNatureType? JobNature { get; set; }
    }
}

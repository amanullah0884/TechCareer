using TechCareer_DLL.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Models.JobSeekers
{
    public class JobApplication: BaseClass
    {
        //[Key]
        //public int Id { get; set; } // Primary Key

        [Required]
        [ForeignKey("JobPost")]
        public int JobPostId { get; set; } // Foreign Key -> JobPost

        [Required]
        [ForeignKey("JobSeeker")]
        public int JobSeekerId { get; set; } // Foreign Key -> JobSeeker

        [Required]
        public DateTime AppliedDate { get; set; } = DateTime.Now;

        [Required]
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending; // Enum Default

        [MaxLength(500)]
        public string? StatusNote { get; set; } // Optional admin note

        [MaxLength(2000)]
        public string? CoverLetter { get; set; } // Optional cover letter

        [ForeignKey("Resume")]
        public int? ResumeId { get; set; } // Optional resume

        // 🔹 Navigation Properties
       // public virtual JobPost? JobPost { get; set; }
        //public virtual JobSeeker? JobSeeker { get; set; }
       // public virtual Resume? Resume { get; set; }

    }
}

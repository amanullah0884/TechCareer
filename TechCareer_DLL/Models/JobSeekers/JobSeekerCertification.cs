using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Models.JobSeekers
{
    public class JobSeekerCertification: BaseClass
    {
        //[Key]
        //public int Id { get; set; } // Primary Key

        [Required]
        [ForeignKey("JobSeeker")]
        public int JobSeekerId { get; set; } // FK -> JobSeeker

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } // Certificate name e.g., "AWS Solutions Architect"

        [Required]
        [MaxLength(200)]
        public string Institution { get; set; } // Certificate issuing organization

        [MaxLength(200)]
        public string? Location { get; set; } // Optional location

        [MaxLength(100)]
        public string? CredentialId { get; set; } // Optional credential ID

        [MaxLength(300)]
        public string? CredentialURL { get; set; } // Optional URL to verify certificate

        [Required]
        public TimeSpan Duration { get; set; } // Duration of course or certificate program

        // 🔹 Navigation property
        public virtual JobSeeker? JobSeeker { get; set; }
    }
}

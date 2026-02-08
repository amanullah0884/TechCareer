using TechCareer_DLL.Models.SiteSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Models.JobSeekers
{
    public class JobSeekerSkill: BaseClass
    {
        //[Key]
        //public int Id { get; set; } // Primary Key

        [Required]
        [ForeignKey("JobSeeker")]
        public int JobSeekerId { get; set; } // FK -> JobSeeker

        [Required]
        [ForeignKey("Skill")]
        public int SkillId { get; set; } // FK -> Skill

        [MaxLength(200)]
        public string? CertificateName { get; set; } // Optional certificate name

        [MaxLength(300)]
        public string? CertificatePath { get; set; } // Optional local path for certificate file

        [MaxLength(300)]
        public string? CertificateURL { get; set; } // Optional URL to certificate

        // 🔹 Navigation properties
        public virtual JobSeeker? JobSeeker { get; set; }
        public virtual Skill? Skill { get; set; }
    }
}

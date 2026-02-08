using TechCareer_DLL.Models.SiteSettings.Education;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Models.JobSeekers
{
    public class JobSeekerEducation: BaseClass
    {

        //[Key]
        //public int Id { get; set; } // Primary Key

        [Required]
        [ForeignKey("JobSeeker")]
        public int JobSeekerId { get; set; } // FK -> JobSeeker

        [Required]
        [ForeignKey("LevelOfEducation")]
        public int LevelOfEducationId { get; set; } // FK -> LevelOfEducation

        [Required]
        [ForeignKey("DegreeOrExam")]
        public int DegreeOrExamId { get; set; } // FK -> DegreeOrExam

        [MaxLength(200)]
        public string? MajorOrGroup { get; set; } // e.g., Computer Science / Science / Business Studies

        [Required]
        [ForeignKey("Institute")]
        public int InstituteId { get; set; } // FK -> Institute

        [Range(0, 100)]
        public float ObtainedResult { get; set; }

        [Range(0, 100)]
        public float ResultScale { get; set; }

        [Range(1900, 2100)]
        public short PassingYear { get; set; }

        [Range(1, 10)]
        public int DurationInYear { get; set; }

        // 🔹 Navigation Properties
        public virtual JobSeeker? JobSeeker { get; set; }
        public virtual LevelOfEducation? LevelOfEducation { get; set; }
        public virtual DegreeOrExam? DegreeOrExam { get; set; }
        public virtual Institution? Institution { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Models.JobSeekers
{
   public class JobSeekerExperience : BaseClass
   {
      [Required]
      [ForeignKey("JobSeeker")]
      [Display(Name = "Job Seeker")]
      public int JobSeekerId { get; set; } // Foreign Key → JobSeeker

      [Required]
      [StringLength(150)]
      [Display(Name = "Company Name")]
      public string CompanyName { get; set; }

      [Required]
      [StringLength(100)]
      [Display(Name = "Designation / Position")]
      public string Designation { get; set; }

      [Required]
      [DataType(DataType.Date)]
      [Display(Name = "Start Date")]
      public DateTime StartDate { get; set; }

      [DataType(DataType.Date)]
      [Display(Name = "End Date")]
      public DateTime? EndDate { get; set; } // Nullable if currently working

      [Display(Name = "Currently Working Here")]
      public bool IsContinue { get; set; }

      [StringLength(1000)]
      [Display(Name = "Key Responsibilities")]
      public string? Responsibilities { get; set; }

      [StringLength(250)]
      [Display(Name = "Area of Expertise")]
      public string? AreaOfExpertise { get; set; }

      // Navigation property → points to JobSeeker
      public virtual JobSeeker JobSeeker { get; set; }
   }
}

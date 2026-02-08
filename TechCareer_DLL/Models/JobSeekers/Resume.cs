using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Models.JobSeekers
{
   public class Resume : BaseClass
   {

   
         [Required]
         [ForeignKey("JobSeeker")]
         [Display(Name = "Job Seeker")]
         public int JobSeekerId { get; set; } // Foreign Key → JobSeeker

         [Required]
         [StringLength(150)]
         [Display(Name = "Resume Title")]
         public string Title { get; set; }

         [Required]
         [StringLength(250)]
         [Display(Name = "Uploaded Resume File Path")]
         public string UploadedResume { get; set; } // e.g. /uploads/resumes/filename.pdf

         // 🔗 Navigation Property
         public virtual JobSeeker JobSeeker { get; set; }

      }

   }

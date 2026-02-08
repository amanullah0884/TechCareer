using TechCareer_DLL.Models.SearchKeyword;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Models.JobSeekers
{
   public class JobSeekersKeyword : BaseClass
   {
      [Required]
      [ForeignKey("JobSeeker")]
      [Display(Name = "Job Seeker")]
      public int JobSeekerId { get; set; } // Foreign Key → JobSeeker

      [Required]
      [ForeignKey("SearchKeyword")]
      [Display(Name = "Search Keyword")]
      public int SearchKeywordId { get; set; } // Foreign Key → SearchKeyword

      [Required]
      [DataType(DataType.DateTime)]
      [Display(Name = "Search Date")]
      public DateTime SearchDate { get; set; } = DateTime.Now; // Default current timestamp

      //  Navigation Properties
      public virtual JobSeeker JobSeeker { get; set; }
      public virtual SearchKeywords SearchKeyword { get; set; }
   }
}

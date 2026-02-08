using TechCareer_DLL.Models.SiteSettings.JobModule;
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
    public class PreferredJobInformation: BaseClass
    {
        //public int Id { get; set; } // Primary Key
    
        [Required]
        [ForeignKey("JobSeeker")]
      public int JobSeekerId { get; set; } // FK -> JobSeeker

      [Required]
      [ForeignKey("JobCategory")]
      public int PreferredJobCategoryId { get; set; } // FK -> JobCategory

      [Required]
      [ForeignKey("Location")]
      public int PreferredJobLocationId { get; set; } // FK -> Location

      [Required]
      [ForeignKey("CompanyCategory")]
      public int PreferredCompanyCategory { get; set; } // FK -> Category (Company type)

      // 🔹 Navigation properties
      public virtual JobSeeker? JobSeeker { get; set; }
        public virtual JobCategory? JobCategory { get; set; }
        public virtual Location? Location { get; set; }
        public virtual CompanyCategory? CompanyCategory { get; set; }


    }
}

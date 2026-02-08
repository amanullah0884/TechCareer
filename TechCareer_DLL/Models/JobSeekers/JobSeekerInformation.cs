using TechCareer_DLL.Models.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Models.JobSeekers
{
   public class JobSeekerInformation : BaseClass
   {
      [Required]
      [ForeignKey("User")]
      [Display(Name = "User")]
      public int UserId { get; set; } // Foreign Key → User table

      [Required]
      [StringLength(150)]
      [Display(Name = "Full Name")]
      public string FullName { get; set; } = string.Empty;

      [StringLength(200)]
      [Display(Name = "Profile Headline")]
      public string? ProfileHeadLine { get; set; }

      [StringLength(1000)]
      [Display(Name = "Profile Summary")]
      public string? ProfileSummary { get; set; }

      [StringLength(250)]
      [DataType(DataType.ImageUrl)]
      [Display(Name = "Profile Picture URL")]
      public string? ProfilePictureUrl { get; set; }

      [StringLength(50)]
      [Display(Name = "Location Id")]
      public string? LocationId { get; set; }

      [Display(Name = "Profile Visibility")]
      public bool ProfileVisibility { get; set; } = true;

      //  Navigation Property
      public virtual User User { get; set; }
      public virtual ICollection<JobSeekerExperience>? Experiences { get; set; }

   }
}

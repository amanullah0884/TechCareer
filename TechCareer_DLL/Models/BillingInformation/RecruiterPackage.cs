using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechCareer_DLL.Models.BillingInformation
{
   public class RecruiterPackage: BaseClass
    {
    
  

      [Required]
      [StringLength(150)]
      [Display(Name = "Package Name")]
      public string PackageName { get; set; } = string.Empty;

      [StringLength(500)]
      [Display(Name = "Description")]
      public string? Description { get; set; }

      [Required]
      [Range(0, double.MaxValue, ErrorMessage = "Regular price must be positive.")]
      [Display(Name = "Regular Price")]
      public decimal RegularPrice { get; set; }

      [Required]
      [Range(0, double.MaxValue, ErrorMessage = "Price for new recruiters must be positive.")]
      [Display(Name = "Price for New Recruiters")]
      public decimal PriceForNew { get; set; }

      [Required]
      [Range(1, 36, ErrorMessage = "Duration should be between 1 and 36 months.")]
      [Display(Name = "Duration (in Months)")]
      public int DurationInMonth { get; set; }

      // Navigation property
      public virtual ICollection<RecruiterSubscription>? RecruiterSubscriptions { get; set; }
   }
}

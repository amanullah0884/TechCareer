using TechCareer_DLL.Models.Recruiters;
using System.ComponentModel.DataAnnotations;

namespace TechCareer_DLL.Models.JobSeekers
{
   public class CompanyCategory: BaseClass
    {
      //[Key]
      //public int Id { get; set; } // Primary Key

      [Required]
      [MaxLength(100)]
      public string CategoryName { get; set; } // e.g., IT, Marketing, HR

      // 🔹 Navigation properties
      public virtual ICollection<JobPost>? JobPosts { get; set; } // One-to-Many: Category -> JobPosts
      public virtual ICollection<PreferredJobInformation>? PreferredJobInformations { get; set; } // Optional: Preferred Job Category
      //public virtual ICollection<PreferredJobInformation>? PreferredCompanyCategories { get; set; } // Optional: Company Category
   }

}